using UnityEditor;
using UnityEngine;
using System.IO;
using CustomTool;
using System.Collections.Generic;
using Entitas.CodeGeneration.Plugins;
using DesperateDevs.Serialization;
using System.Linq;
using Entitas;
using System.Text;
using System;

namespace Game.Editor
{
    /// <summary>
    /// 生成Entatis框架代码工具
    /// </summary>
    public class GenerateEntitasCodeWindow : EditorWindow 
    {

        private static string viewPath;
        private static string servicePath;
        private static string systemPath;
        private static string dataPath = "Assets/Editor/AutoGenerateFrameCode/Data/";
        private static string dataFileName = "EntitasData.asset";
        private static string viewPostfix = "View";
        private static string viewName;
        private static string servicePostfix = "Service";
        private static string serviceName;
        private static string systemPosfix = "System";
        private static string systemName;
        private static string namespaceBase = "Game";
        private static string[] contextNames;
        private static Dictionary<string, bool> contextSelectedStateDic;
        private static string selectedContextName;
        private static string otherSystemName;

        private static string[] systemInterfaceNames =
        {
            "IInitializeSystem",
            "IExecuteSystem",
            "ICleanupSystem",
            "ITearDownSystem"
        };

        private static Dictionary<string, bool> systemSelectedStateDic;
        private static int lineSpace;

        private static GUIStyle mainTitle = new GUIStyle();
        private static GUIStyle itemTitle = new GUIStyle();

        [MenuItem("Tools/GenerateEntatisCode")]
       public static void OpenWindow()
        {
            var window = GetWindow(typeof(GenerateEntitasCodeWindow));
            window.minSize = new Vector2(600, 800);
            window.Show();
            Init();

        }

        private static void Init()
        {
            lineSpace = 15;
            ReadDataFromLocal();
            GetContextName();
            InitContextSelectdState();
            selectedContextName = contextNames[0];
            InitSystemSelectdState();
            InitGUIStyle();
        }

        #region ContextSelectedState
        private static void InitContextSelectdState()
        {
            contextSelectedStateDic = new Dictionary<string, bool>();
            ResetContextSelectedState();
        }

        private static void ResetContextSelectedState()
        {
            foreach (string contextName in contextNames)
            {
                contextSelectedStateDic[contextName] = false;
            }
        }
        #endregion

        #region SystemSelectedState
        private static void InitSystemSelectdState()
        {
            systemSelectedStateDic = new Dictionary<string, bool>();
            ResetSystemSelectedState();
        }

        private static void ResetSystemSelectedState()
        {
            foreach (string systemName in systemInterfaceNames)
            {
                systemSelectedStateDic[systemName] = false;
            }
        }
        #endregion

        private static void InitGUIStyle()
        {
            mainTitle.alignment = TextAnchor.MiddleCenter;
            mainTitle.normal.textColor = Color.white;
            mainTitle.fontSize = 30;
            mainTitle.fontStyle = FontStyle.Bold;

            itemTitle.normal.textColor = Color.gray;
            itemTitle.fontSize = 15;
            itemTitle.fontStyle = FontStyle.Bold;
        }

        private void OnGUI()
        {
            if(mainTitle != null)
               GUILayout.Label("生成Entitas框架代码工具",mainTitle);

            Path();

            View();

            Service();

            ReactiveSystem();

            OtherSystem();
        }

        private void Path()
        {
            GUILayout.Space(lineSpace);
            GUILayout.Label("脚本路径",itemTitle);
            PathItem("View 层路径", ref viewPath);
            PathItem("Service 层路径", ref servicePath);
            PathItem("System 层路径", ref systemPath);
            CreateButton("保存路径", () => { });
        }

        private void View()
        {
            GUILayout.Space(lineSpace);
            InputName("请输入脚本名称", ref viewName);
            CreateButton("生成脚本",() => 
            {
                CreateScript(viewPath, viewName + viewPostfix, GetViewCode());
            }
            );
        }

        private void Service()
        {
            GUILayout.Space(lineSpace);
            InputName("请输入脚本名称", ref serviceName);
            CreateButton("生成脚本", () => 
            {
                CreateScript(servicePath, serviceName + servicePostfix, GetServiceCode());
            }
            );
        }

        private void ReactiveSystem()
        {
            GUILayout.Space(lineSpace);
            GUILayout.Label("选择要生成系统的上下文",itemTitle);
            GUILayout.BeginHorizontal();
            if (contextSelectedStateDic != null)
            {
                foreach (KeyValuePair<string, bool> pair in contextSelectedStateDic)
                {
                    if (GUILayout.Toggle(pair.Value, pair.Key) && pair.Value == false)
                    {
                        selectedContextName = pair.Key;
                    }
                }
                ToggleGroup(selectedContextName);
            }
            GUILayout.EndHorizontal();
            InputName("请输入脚本名称", ref systemName);

            CreateButton("生成脚本", () => 
            {
                CreateScript(systemPath, systemName + systemPosfix, GetReactiveSystemCode());
            }
            );
        }

        private void OtherSystem()
        {
            GUILayout.Space(lineSpace);
            GUILayout.Label("选择要生成的系统", itemTitle);
            if (systemSelectedStateDic != null)
            {
                foreach (string systemName in systemInterfaceNames)
                {
                    systemSelectedStateDic[systemName] = GUILayout.Toggle(systemSelectedStateDic[systemName], systemName);
                }
            }
            InputName("请输入脚本名称", ref otherSystemName);
            CreateButton("生成脚本", () => 
            {
                CreateScript(systemPath, systemName + systemPosfix, GetOtherSystemCode());
            }
            );
        }

        private void InputName(string title,ref string name)
        {
            GUILayout.Label(title,itemTitle);
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            name = EditorGUI.TextField(rect, name);
        }

        private static void CreateButton(string btnName,Action callBack)
        {
            if (GUILayout.Button(btnName, GUILayout.Width(150)))
            {
                callBack?.Invoke();
            }
        }

        private static void ToggleGroup(string name)
        {
            if (contextSelectedStateDic.ContainsKey(name))
            {
                ResetContextSelectedState();
                contextSelectedStateDic[name] = true;
            }
        }

        /// <summary>
        /// 路径UI显示及输入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        private void PathItem(string name,ref string path)
        {
            GUILayout.Label(name);
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            viewPath = EditorGUI.TextField(rect, path);
            DragToGetPath(rect, ref path);
        }

        /// <summary>
        /// 拖动文件夹获取路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="path"></param>
        private void DragToGetPath(Rect rect,ref string path)
        {
            if((Event.current.type == EventType.DragUpdated
            || Event.current.type == EventType.DragExited)
            && rect.Contains(Event.current.mousePosition))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                {
                    path = DragAndDrop.paths[0];
                }
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        private static void SaveDataToLocal()
        {
            Directory.CreateDirectory(dataPath);
            EntitasData data = new EntitasData();
            data.viewPath = viewPath;
            data.servicePath = servicePath;
            data.systemPath = systemPath;
            AssetDatabase.CreateAsset(data, dataPath + dataFileName);
        }

        /// <summary>
        /// 读取数据从本地
        /// </summary>
        private static void ReadDataFromLocal()
        {
            EntitasData data = AssetDatabase.LoadAssetAtPath<EntitasData>(dataPath + dataFileName);
            if(data != null)
            {
                viewPath = data.viewPath;
                servicePath = data.servicePath;
                systemPath = data.systemPath;
            }
        }

        public static void GetContextName()
        {
            var provider = new ContextDataProvider();
            provider.Configure(Preferences.sharedInstance);
            var data = (ContextData[])provider.GetData();
            contextNames = data.Select(p => p.GetContextName()).ToArray();
        }

        private static string GetViewCode()
        {
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteUsing("Entitas.Unity");
            build.WriteNameSpace(namespaceBase + "." + viewPostfix);
            build.WriteEmptyLine();
            build.IndentTimes++;
            build.WriteClass(viewName + viewPostfix, "ViewBase");
            List<string> keyName = new List<string>();
            keyName.Add("override");
            keyName.Add("void");
            build.IndentTimes++;
            build.WriteFun("Init",ScriptBuildHelp.Public, keyName,"", "Contexts contexts", "IEntity entity");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("base.Init(contexts,entity);",true);
            build.ToContentEnd();
            return build.ToString();
        }

        private static string GetServiceCode()
        {
            ScriptBuildHelp build = new ScriptBuildHelp();
            string className = serviceName + servicePostfix;
            build.WriteNameSpace(namespaceBase + "." + servicePostfix);
            build.WriteEmptyLine();
            build.WriteInterface("I" + className, "InitService");
            build.ToContentEnd();

            build.WriteClass(className, "I" + className);
            var keyName = new List<string>();
            keyName.Add("void");
            build.WriteFun("Init",ScriptBuildHelp.Private ,keyName,"", "Contexts contexts");
            build.BackToInsertContent();
            build.WriteLine("//contexts.service.SetGameService" + className + "(this);",true);
            build.ToContentEnd();

            var key = new List<string>();
            key.Add("int");
            build.WriteFun("GetPriority",ScriptBuildHelp.Protected, key);
            build.BackToInsertContent();
            build.WriteLine("return 0;",true);
            build.ToContentEnd();
            return build.ToString();
        }

        private static string GetReactiveSystemCode()
        {
            string className = selectedContextName + systemName + systemPosfix;
            string entityName = selectedContextName + "Entity";
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteEmptyLine(); 
            build.WriteClass(className, "ReactiveSystem<" + entityName +  ">");
            build.WriteLine("protected Contexts contexts;", true);
            build.WriteEmptyLine();
            //构造
            build.WriteFun(className, ScriptBuildHelp.Public, new List<string>(), ": base(contexts.game)", "Contexts contexts");
            build.BackToInsertContent();
            build.WriteLine("this.contexts = contexts;");
            build.ToContentEnd();
            build.WriteEmptyLine();

            //GetTrigger
            List<string> triggerKeys = new List<string>();
            triggerKeys.Add("override");
            triggerKeys.Add("ICollector<" + entityName + ">");
            build.WriteFun("GetTrigger",ScriptBuildHelp.Protected, triggerKeys," ", "IContext<"+ entityName + "> context");
            build.BackToInsertContent();
            build.WriteLine("return context.CreateCollector(" + selectedContextName + "Matcher.Game" + selectedContextName + systemName + ");",true);
            build.ToContentEnd();
            //Filter
            List<string> filterKeys = new List<string>();
            filterKeys.Add("override");
            filterKeys.Add("bool");
            build.WriteFun("Filter", ScriptBuildHelp.Protected, filterKeys, "", entityName + "entity");
            build.BackToInsertContent();
            build.WriteLine(" return entity.hasGame"+ selectedContextName + systemName + ";",true);
            build.ToContentEnd();
            //Execute
            List<string> executeKeys = new List<string>();
            filterKeys.Add("override");
            filterKeys.Add("void");
            build.WriteFun("Execute", ScriptBuildHelp.Protected, executeKeys, "", "List<" + entityName + "> entities");
            return build.ToString();
        }

        private static string GetOtherSystemCode()
        {
            string className = otherSystemName + systemPosfix;
            List<string> selectedSystem = GetSelectedSystem();
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteNameSpace(namespaceBase);
            build.WriteEmptyLine();
            build.WriteClass(className, GetSelectedSystem(selectedSystem));
            build.WriteLine("protected Contexts contexts;", true);
            build.WriteEmptyLine();
            //构造
            build.WriteFun(className,ScriptBuildHelp.Public,new List<string>(), " ","Contexts contexts");
            build.BackToInsertContent();
            build.WriteLine("this.contexts = contexts;");
            build.ToContentEnd();
            //实现方法
            List<string> funcName = GetFuncName(selectedSystem);
            List<string> keyName = new List<string>();
            keyName.Add("void");
            foreach (string func in funcName)
            {
                build.WriteFun(func, ScriptBuildHelp.Public, keyName);
            }

            return build.ToString();
        }
        private static List<string> GetSelectedSystem()
        {
            List<string> temp = new List<string>();
            foreach (KeyValuePair<string,bool> pair in systemSelectedStateDic)
            {
                if(pair.Value)
                {
                    temp.Add(pair.Key);
                }
            }

            return temp;
         }

        private static string GetSelectedSystem(List<string> selected)
        {
            StringBuilder build = new StringBuilder();
            foreach (string pair in selected)
            {
                    build.Append(pair);
                    build.Append(" , ");
            }
            build.Remove(build.Length - 4, 3);
            return build.ToString();
        }

        private static List<string> GetFuncName(List<string> selected)
        {
            List<string> temp = new List<string>();
            foreach (string interfaceName in selected)
            {
                temp.Add(interfaceName.Substring(1, interfaceName.Length - 7));
            }
            return temp;
        }

        private static void CreateScript(string path,string className,string scriptContent)
        {
            if(Directory.Exists(path))
            {
                File.WriteAllText(path + "/" +  className + ".cs", scriptContent);
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogError("目录：" + path + "不存在！");
            }
        }
    }
}
