using UnityEditor;
using UnityEngine;
using System.IO;
using CustomTool;
using System.Collections.Generic;
using Entitas.CodeGeneration.Plugins;
using DesperateDevs.Serialization;
using System.Linq;

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
        private static string namespaceName = "Game";
        private static string[] contextNames;
        private static Dictionary<string, bool> contextSelectedStateDic;
        private static string selectedContextName;
        [MenuItem("Tools/GenerateEntatisCode")]
       public static void OpenWindow()
        {
            var window = GetWindow(typeof(GenerateEntitasCodeWindow));
            window.minSize = new Vector2(500, 600);
            window.Show();
            Init();
            Debug.Log(GetSystemCode());

        }

        private static void Init()
        {
            ReadDataFromLocal();
            GetContextName();
            InitContextSelectdState();
            selectedContextName = contextNames[0];
        }

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

        private void OnGUI()
        {
            GUILayout.Label("生成Entitas框架代码工具");
            GUILayout.Space(5);
            GUILayout.Label("脚本路径");
            PathItem("View 层路径",ref viewPath);
            PathItem("Service 层路径", ref servicePath);
            PathItem("System 层路径", ref systemPath);
            if(GUILayout.Button("保存路径",GUILayout.Width(500)))
            {
                SaveDataToLocal();
            }
            GUILayout.Space(5);
            GUILayout.Label("View 层代码生成");
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            viewPath = EditorGUI.TextField(rect, viewName) ;

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
                if(DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
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
            build.WriteNameSpace(namespaceName + "." + viewPostfix);
            build.WriteEmptyLine();
            build.WriteClass(viewName + viewPostfix, "ViewBase");
            List<string> keyName = new List<string>();
            keyName.Add("override");
            keyName.Add("void");
            build.WriteFun("Init",ScriptBuildHelp.Private, keyName,"", "Contexts contexts", "IEntity entity");
            build.BackToInsertContent();
            build.WriteLine("base.Init(contexts,entity);",true);
            build.ToContentEnd();
            return build.ToString();
        }

        private static string GetServiceCode()
        {
            ScriptBuildHelp build = new ScriptBuildHelp();
            string className = serviceName + servicePostfix;
            build.WriteNameSpace(namespaceName + "." + servicePostfix);
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

        private static string GetSystemCode()
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
    }
}
