using UnityEditor;
using UnityEngine;
using System.IO;
using CustomTool;
using System.Collections.Generic;

namespace Game.Editor
{
    /// <summary>
    /// ����Entatis��ܴ��빤��
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


        [MenuItem("Tools/GenerateEntatisCode")]
       public static void OpenWindow()
        {
            var window = GetWindow(typeof(GenerateEntitasCodeWindow));
            window.minSize = new Vector2(500, 600);
            window.Show();
            Init();
            Debug.Log(GetViewCode());

        }

        private static void Init()
        {
            ReadDataFromLocal();
        }

        private void OnGUI()
        {
            GUILayout.Label("����Entitas��ܴ��빤��");
            GUILayout.Space(5);
            GUILayout.Label("�ű�·��");
            PathItem("View ��·��",ref viewPath);
            PathItem("Service ��·��", ref servicePath);
            PathItem("System ��·��", ref systemPath);
            if(GUILayout.Button("����·��",GUILayout.Width(500)))
            {
                SaveDataToLocal();
            }
            GUILayout.Space(5);
            GUILayout.Label("View ���������");
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            viewPath = EditorGUI.TextField(rect, viewName) ;
        }

        /// <summary>
        /// ·��UI��ʾ������
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
        /// �϶��ļ��л�ȡ·��
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
        /// �������ݵ�����
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
        /// ��ȡ���ݴӱ���
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

        private static string GetViewCode()
        {
            ScriptBuildHelp buildHelp = new ScriptBuildHelp();
            buildHelp.WriteUsing("Entitas");
            buildHelp.WriteUsing("Entitas.Unity");
            buildHelp.WriteNameSpace("Game." + viewPostfix);
            buildHelp.WriteEmptyLine();
            buildHelp.WriteClass(viewName + viewPostfix, "ViewBase");
            List<string> keyName = new List<string>();
            keyName.Add("override");
            buildHelp.WriteFun( keyName,"Init", "Contexts contexts", "IEntity entity");
            buildHelp.BackToInsertContent();
            buildHelp.WriteFuncContent("base.Init(contexts,entity);");
            buildHelp.ToContentEnd();
            return buildHelp.ToString();
        }
    }
}
