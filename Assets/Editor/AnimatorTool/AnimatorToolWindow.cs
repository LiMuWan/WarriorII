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
        private static EditorWindow window;

        private static string animatorPath;
        private static string cachePath = "Assets/Editor/AnimatorTool/Cache/";
        private static string cacheName = "AnimatorToolCache.asset";
        private static string aniControllerPath;
        private static string newAniName;
        [SerializeField]
        private List<GameObject> animationObjects = new List<GameObject>();

        private static SerializedObject serializedObject;
        private static SerializedProperty animations;

        private static GenerateController generater;

        public static void OpenWindow()
        {
            window = GetWindow(typeof(AnimatorToolWindow));
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
        [MenuItem("Assets/AnimatorTool")]
        public static void ShowWindowInProject()
        {
            OpenWindow();
        }

        //在工程视图界面下的检测函数
        [MenuItem("Assets/AnimatorTool",true)]
        public static bool ShowWindowInProjectValidate()
        {
            return Selection.activeObject.GetType() == typeof(AnimatorController)
                || Selection.activeObject.GetType() == typeof(GameObject);
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            PathItem("AnimatorController存放路径", ref aniControllerPath);
            CreateButton("保存", SaveDataToLocal);
            GUILayout.Space(10);
            InputName("新建AnimatorController名称", ref newAniName);
            GetAnimationObject();
            CreateButton("创建", CreateNewController);
            
        }

        private void GetAnimationObject()
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(animations, true);

            if(EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        //获取动画资源方式是有坑的  
        private void CreateNewController()
        {
            List<AnimationClip> clips = GetAnimationClip();
            if (clips != null && clips.Count > 0)
            {
                generater.Create(aniControllerPath,newAniName, clips);
            }
            else
            {
                Debug.LogError("获取动画片段失败，无法创建AnimationController");
            }
        }

        /// <summary>
        /// 获取动画片段文件
        /// </summary>
        /// <returns></returns>
        private List<AnimationClip> GetAnimationClip()
        {
            if (animationObjects.Count == 0)
                return null;

            List<AnimationClip> clips = new List<AnimationClip>();

            foreach (GameObject gameObject in animationObjects)
            {
                string path = AssetDatabase.GetAssetPath(gameObject);
                var assets = AssetDatabase.LoadAllAssetsAtPath(path);
                foreach (UnityEngine.Object asset in assets)
                {
                    if(asset is AnimationClip)
                    {
                        AnimationClip clip = asset as AnimationClip;
                        if(!clip.name.Contains("Take"))
                        {
                            clips.Add(clip);
                        }
                        else
                        {
                            Debug.Log(asset.name);
                        }
                    }
                }
            }
            return clips;
        }

        private static void Init()
        {
            ReadDataFromLocal();
            generater = new GenerateController();
        }

        private void InitAnimationList()
        {
            animationObjects = Selection.gameObjects.ToList();
        }

        private void OnEnable()
        {
            serializedObject = new SerializedObject(this);
            animations = serializedObject.FindProperty("animationObjects");
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
                    Close();
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

        public static void Close()
        {
            AssetDatabase.Refresh();
            window.Close();
        }
    }
}
