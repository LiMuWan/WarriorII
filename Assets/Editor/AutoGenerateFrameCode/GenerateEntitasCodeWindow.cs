 using UnityEditor;
using UnityEngine;
using System.IO;
using CustomTool;
using System.Collections.Generic;
using Entitas.CodeGeneration.Plugins;
using DesperateDevs.Serialization;
using System.Linq;
using System.Text;
using System;
   
namespace Game.Editor
{
    /// <summary>
    /// 生成Entatis框架代码工具
    /// </summary>
    public class GenerateEntitasCodeWindow : EditorWindow
    {
        private static GUIStyle mainTitle = new GUIStyle();
        private static GUIStyle itemTitle = new GUIStyle();
        private static EditorWindow window;

        [MenuItem("Tools/GenerateEntatisCode %+,")] //快捷键 # 代表shift，&代表alt, % 代表ctrl
        public static void OpenWindow()
        {
            window = GetWindow(typeof(GenerateEntitasCodeWindow));
            window.minSize = new Vector2(600, 800);
            window.Show();
            Init();

        }

        public static void Close()
        {
            AssetDatabase.Refresh();
            window.Close();
        }

        private static void Init()
        {
            ToolData.Init();
            InitGUIStyle();
        }

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
            if (mainTitle != null)
                GUILayout.Label("生成Entitas框架代码工具", mainTitle);

            Path();

            View();

            Service();

            SelectedContext();

            ReactiveSystem();

            OtherSystem();
        }

        private void Path()
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("脚本路径", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            PathItem("View 层路径", ref ToolData.viewPath);
            PathItem("Service 层路径", ref ToolData.servicePath);
            PathItem("System 层路径", ref ToolData.systemPath);

            GUILayout.Space(ToolData.lineSpace);
            PathItem("ServiceManager路径", ref ToolData.serviceManagerPath);
            PathItem("GameFeature路径", ref ToolData.gameFeaturePath);
            PathItem("InputFeature路径", ref ToolData.inputFeaturePath);
            PathItem("ViewFeature路径", ref ToolData.viewFeaturePath);

            CreateButton("保存路径", () =>
            {
                ToolData.SaveDataToLocal();
            }
            );
        }

        private void View()
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("View 层代码生成", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            InputName("请输入脚本名称", ref ToolData.viewName);
            CreateButton("生成脚本", () =>
             {
                 GenerateCode.CreateScript(ToolData.viewPath, ToolData.viewName + ToolData.viewPostfix,
                     CodeTemplate.GetViewCode());
             }
            );
        }

        private void Service()
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("Service 层代码生成", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            InputName("请输入脚本名称", ref ToolData.serviceName);
            CreateButton("生成脚本", () =>
            {
                GenerateCode.CreateScript(ToolData.servicePath, ToolData.serviceName + ToolData.servicePostfix, 
                    CodeTemplate.GetServiceCode());
                GenerateCode.InitServices(ToolData.serviceManagerPath);
            }
            );
        }

        private void ReactiveSystem()
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("响应系统部分", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            InputName("请输入脚本名称", ref ToolData.systemName);
            CreateButton("生成脚本", () =>
            {
                GenerateCode.CreateScript(ToolData.systemPath, ToolData.selectedContextName + ToolData.systemName + 
                    ToolData.systemPosfix, CodeTemplate.GetReactiveSystemCode());
                GenerateCode.InitSystem(ToolData.selectedContextName, ToolData.selectedContextName + ToolData.systemName + 
                    ToolData.systemPosfix, "ReactiveSystem");
            }
            );
        }

        private void SelectedContext( )
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("选择生成系统的上下文", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.BeginHorizontal();
            if (ToolData.contextSelectedStateDic != null)
            {
                foreach (KeyValuePair<string, bool> pair in ToolData.contextSelectedStateDic)
                {
                    if (GUILayout.Toggle(pair.Value, pair.Key) && pair.Value == false)
                    {
                        ToolData.selectedContextName = pair.Key;
                    }
                }
                ToggleGroup(ToolData.selectedContextName);
            }
            GUILayout.EndHorizontal();
        }

        private void OtherSystem()
        {
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("其他系统部分", itemTitle);
            GUILayout.Space(ToolData.lineSpace);
            GUILayout.Label("选择要生成的系统");
            if (ToolData.systemSelectedStateDic != null)
            {
                foreach (string systemName in ToolData.systemInterfaceNames)
                {
                    ToolData.systemSelectedStateDic[systemName] = GUILayout.Toggle(ToolData.systemSelectedStateDic[systemName], systemName);
                }
            }
            GUILayout.Space(ToolData.lineSpace);
            InputName("请输入脚本名称", ref ToolData.otherSystemName);
            CreateButton("生成脚本", () =>
            {
                GenerateCode.CreateScript(ToolData.systemPath, ToolData.selectedContextName + ToolData.otherSystemName + ToolData.systemPosfix, CodeTemplate.GetOtherSystemCode());
                List<string> selectedSystem = CodeTemplate.GetSelectedSystem();
                List<string> funcName = CodeTemplate.GetFuncName(selectedSystem);
                GenerateCode.InitSystem(ToolData.selectedContextName, ToolData.selectedContextName + ToolData.otherSystemName + ToolData.systemPosfix, funcName.ToArray());
            }
            );
        }

        private void InputName(string title, ref string name)
        {
            GUILayout.Label(title);
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            name = EditorGUI.TextField(rect, name);
        }

        private static void CreateButton(string btnName, Action callBack)
        {
            if (GUILayout.Button(btnName, GUILayout.Width(150)))
            {
                if (!string.IsNullOrEmpty(btnName))
                {
                    Close();
                    callBack?.Invoke();
                }
            }
        }

        private static void ToggleGroup(string name)
        {
            if (ToolData.contextSelectedStateDic.ContainsKey(name))
            {
                ToolData.ResetContextSelectedState();
                ToolData.contextSelectedStateDic[name] = true;
            }
        }

        /// <summary>
        /// 路径UI显示及输入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        private void PathItem(string name, ref string path)
        {
            GUILayout.Label(name);
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            path = EditorGUI.TextField(rect, path);
            DragToGetPath(rect, ref path);
        }

        /// <summary>
        /// 拖动文件夹获取路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="path"></param>
        private void DragToGetPath(Rect rect, ref string path)
        {
            if ((Event.current.type == EventType.DragUpdated
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
    }
}
