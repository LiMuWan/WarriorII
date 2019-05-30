using UnityEditor;
using UnityEngine;
using System.IO;

namespace CustomTool
{
    public class AddNamespaceWindow : EditorWindow   
    {
        private static string name;
        private static string path = "Assets/Editor/AutoAddNamespace/Cache/";
        private static string dataName = "Data.asset";

        [MenuItem("Tools/AddNamespace")]
        public static void OpenWindow()
        {
            var window = GetWindow(typeof(AddNamespaceWindow));
            window.minSize = new Vector2(500, 300);
            window.Show();
            Init(); 
        }

        public static AddNamespaceData GetData()
        {
            AddNamespaceData data = AssetDatabase.LoadAssetAtPath<AddNamespaceData>(path + dataName);
            return data;
        }

        private static void Init()
        {
           AddNamespaceData data =  AssetDatabase.LoadAssetAtPath<AddNamespaceData>(path + dataName);
            if(data != null)
            {
                name = data.name;  
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("命名空间名称");
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(200));
            name = EditorGUI.TextField(rect, name);

            if(GUILayout.Button("完成",GUILayout.MaxWidth(100)))
            {
                AddNamespaceData data = new AddNamespaceData();
                data.name = name;

                Directory.CreateDirectory(path);
                AssetDatabase.CreateAsset(data,path + dataName);
            }
        }
    }
}
