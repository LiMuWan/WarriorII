using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomTool
{
    public class AnimatorToolWindow:EditorWindow     
    {
        private static AnimatorToolWindow window;

        private static string animatorPath;
        private static string cachePath = "Assets/Editor/AnimatorTool/Cache/";
        private static string cacheName = "AnimatorToolCache.asset";
        private static string aniControllerPath;
        private static string newAniName;
        [SerializeField]
        public List<GameObject> animationObjects = new List<GameObject>();
        [SerializeField]
        public List<SubAnimatorMachineItem> subAnimatorMachineItems = new List<SubAnimatorMachineItem>();
        private static SerializedObject serializedObject;
        private static SerializedProperty animations;
        private static SerializedProperty subAnimatorMachines;

        private static GenerateController generater;
        private CustomReorderableList customReorderableList;

        private bool isAddDefaultAnis;

        public static void OpenWindow()
        {
            window = (AnimatorToolWindow)GetWindow(typeof(AnimatorToolWindow));
            window.minSize = new Vector2(500, 800);
            window.Show();
            Init();
        }

        [MenuItem("Tools/AnimatorTool %m")]
        public static void ShowWindowInMenu()
        {
            OpenWindow();
        }

        //�ڼ�������Ҽ��˵�,priority > 50 ����ʾ
        [MenuItem("GameObject/AnimatorTool",priority = 0)]
        public static void ShowWindowInHierachy()
        {
            OpenWindow();
        }

        //�ڹ�����ͼ��������ʾ
        [MenuItem("Assets/AnimatorTool/Add")]
        public static void ShowWindowInProject()
        {
            AutoAddAniObjects();
        }

        //�ڹ�����ͼ�����µļ�⺯��
        [MenuItem("Assets/AnimatorTool/Add",true)]
        public static bool ShowWindowInProjectValidate()
        {
            return Selection.activeObject.GetType() == typeof(GameObject);
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            PathItem("AnimatorController���·��", ref aniControllerPath);
            CreateButton("����", SaveDataToLocal);
            GUILayout.Space(10);
            InputName("�½�AnimatorController����", ref newAniName);
            UpdateSerializedObject();
            CreateButton("����", CreateNewController);
            AddAniToogle();
        }

        private static void AutoAddAniObjects()
        {
            AddAniObjects(window.animationObjects, Selection.gameObjects.ToList());
            foreach (SubAnimatorMachineItem item in window.subAnimatorMachineItems)
            {
                if (item.IsAutoAdd)
                {
                    AddAniObjects(item.AnimationObjects, Selection.gameObjects.ToList());
                }
            }
        }

        private static void AddAniObjects(List<GameObject> data,List<GameObject> selection)
        {
            foreach (GameObject gameObject in selection)
            {
                if(!data.Contains(gameObject))
                {
                    data.Add(gameObject);
                }
            }
        }

        private void AddAniToogle()
        {
            isAddDefaultAnis = GUILayout.Toggle(isAddDefaultAnis, new GUIContent("Ĭ��״̬��"));

            foreach (SubAnimatorMachineItem item in subAnimatorMachineItems)
            {
                item.IsAutoAdd = GUILayout.Toggle(item.IsAutoAdd, new GUIContent(item.SubMachineName));
            }
        }

        private void UpdateSerializedObject()
        {
            serializedObject.Update();
            //����޸�
            EditorGUI.BeginChangeCheck();
            GetAnimationObject();
            customReorderableList.OnGUI();
            //�����޸�
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        private void GetAnimationObject()
        {
            EditorGUILayout.PropertyField(animations,new GUIContent("Ĭ�ϲ㼶����Ƭ������"), true);
        }

        //��ȡ������Դ��ʽ���пӵ�  
        private void CreateNewController()
        {
            bool success = generater.Create(aniControllerPath, newAniName, animationObjects, subAnimatorMachineItems);
            if ( !success )
            {
                Debug.LogError("��ȡ����Ƭ��ʧ�ܣ��޷�����AnimationController");
            }
        }

        private static void Init()
        {
            ReadDataFromLocal(); 
        }

        private void InitAnimationList()
        {
            animationObjects = Selection.gameObjects.ToList();
        }

        private void OnEnable()
        {
            generater = new GenerateController();
            serializedObject = new SerializedObject(this);
            animations = serializedObject.FindProperty("animationObjects");
            subAnimatorMachines = serializedObject.FindProperty("subAnimatorMachineItems");
            customReorderableList = new CustomReorderableList(serializedObject, subAnimatorMachines);
            InitAnimationList();
        }

        /// <summary>
        /// �������ݵ�����
        /// </summary>
        private static void SaveDataToLocal()
        {
            Directory.CreateDirectory(cachePath);
            AnimatorToolData data = new AnimatorToolData();
            data.AnimatorControllerPath = aniControllerPath;
            AssetDatabase.CreateAsset(data, cachePath + cacheName);
        }

        /// <summary>
        /// �ӱ��ض�ȡ����
        /// </summary>
        private static void ReadDataFromLocal()
        {
            AnimatorToolData data = AssetDatabase.LoadAssetAtPath<AnimatorToolData>(cachePath + cacheName);
           if(data != null)
            {
                aniControllerPath = data.AnimatorControllerPath;
            }
        }

        /// <summary>
        /// ·��UI��ʾ������
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
        /// �϶��ļ��л�ȡ·��
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

        //����button
        private static void CreateButton(string btnName, Action callBack)
        {
            if (GUILayout.Button(btnName, GUILayout.Width(150)))
            {
                if (!string.IsNullOrEmpty(btnName))
                {
                    CloseWindow();
                    callBack?.Invoke();
                }
            }
        }

        /// <summary>
        /// ����Ҫ���ɽű���������
        /// </summary>
        /// <param name="title"></param>
        /// <param name="name"></param>
        private void InputName(string title, ref string name)
        {
            GUILayout.Label(title);
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(150));
            name = EditorGUI.TextField(rect, name);
        }

        public static void CloseWindow()
        {
            AssetDatabase.Refresh();
        }
    }
}
