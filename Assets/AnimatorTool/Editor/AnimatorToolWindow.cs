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
        private static string cachePath = "Assets/AnimatorTool/Editor/Cache/";
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

        public static List<AnimatorController> HelpControllers
        {
            get
            {
                ReadDataFromLocal();
                return helpControllers;
            }
        }

        private static List<AnimatorController> helpControllers = new List<AnimatorController>();

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

        //在检视面板右键菜单,priority > 50 不显示
        [MenuItem("GameObject/AnimatorTool",priority = 0)]
        public static void ShowWindowInHierachy()
        {
            OpenWindow();
        }

        //在工程视图界面下显示
        [MenuItem("Assets/AnimatorTool/Add")]
        public static void ShowWindowInProject()
        {
            AutoAddAniObjects();
        }

        //在工程视图界面下显示
        [MenuItem("Assets/AnimatorTool/AddAnimatorHelp")]
        public static void AddAnimatorHelpInProject()
        {
            AnimatorController aniCtrl = AnimatorHelpManager.Instance.Add();
            if(aniCtrl != null && !helpControllers.Contains(aniCtrl))
            {
                helpControllers.Add(aniCtrl);
                SaveDataToLocal();
            }
        }

        //在工程视图界面下的检测函数
        [MenuItem("Assets/AnimatorTool/AddAnimatorHelp", true)]
        public static bool AddAnimatorHelpInProjectValidate()
        {
            return Selection.activeObject.GetType() == typeof(AnimatorController);
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            PathItem("AnimatorController存放路径", ref aniControllerPath);
            CreateButton("保存", SaveDataToLocal);
            GUILayout.Space(10);
            InputName("新建AnimatorController名称", ref newAniName);
            UpdateSerializedObject();
            CreateButton("创建", CreateNewController);
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
            isAddDefaultAnis = GUILayout.Toggle(isAddDefaultAnis, new GUIContent("默认状态机"));

            foreach (SubAnimatorMachineItem item in subAnimatorMachineItems)
            {
                item.IsAutoAdd = GUILayout.Toggle(item.IsAutoAdd, new GUIContent(item.SubMachineName));
            }
        }

        private void UpdateSerializedObject()
        {
            serializedObject.Update();
            //检查修改
            EditorGUI.BeginChangeCheck();
            GetAnimationObject();
            customReorderableList.OnGUI();
            //结束修改
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        private void GetAnimationObject()
        {
            EditorGUILayout.PropertyField(animations,new GUIContent("默认层级动画片段数组"), true);
        }

        //获取动画资源方式是有坑的  
        private void CreateNewController()
        {
            bool success = generater.Create(aniControllerPath, newAniName, animationObjects, subAnimatorMachineItems);
            if ( !success )
            {
                Debug.LogError("获取动画片段失败，无法创建AnimationController");
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
        /// 保存数据到本地
        /// </summary>
        private static void SaveDataToLocal()
        {
            Directory.CreateDirectory(cachePath);
            AnimatorToolData data = new AnimatorToolData();
            data.AnimatorControllerPath = aniControllerPath;
            data.HelpControllers = helpControllers;
            AssetDatabase.CreateAsset(data, cachePath + cacheName);
        }

        /// <summary>
        /// 从本地读取数据
        /// </summary>
        private static void ReadDataFromLocal()
        {
            AnimatorToolData data = AssetDatabase.LoadAssetAtPath<AnimatorToolData>(cachePath + cacheName);
           if(data != null)
            {
                aniControllerPath = data.AnimatorControllerPath;
                helpControllers = data.HelpControllers;
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

        //生成button
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
        /// 输入要生成脚本的主名称
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
