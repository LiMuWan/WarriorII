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

        //�ڼ�������Ҽ��˵�,priority > 50 ����ʾ
        [MenuItem("GameObject/AnimatorTool",priority = 0)]
        public static void ShowWindowInHierachy()
        {
            OpenWindow();
        }

        //�ڹ�����ͼ��������ʾ
        [MenuItem("Assets/AnimatorTool")]
        public static void ShowWindowInProject()
        {
            OpenWindow();
        }

        //�ڹ�����ͼ�����µļ�⺯��
        [MenuItem("Assets/AnimatorTool",true)]
        public static bool ShowWindowInProjectValidate()
        {
            return Selection.activeObject.GetType() == typeof(AnimatorController)
                || Selection.activeObject.GetType() == typeof(GameObject);
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            PathItem("AnimatorController���·��", ref aniControllerPath);
            CreateButton("����", SaveDataToLocal);
            GUILayout.Space(10);
            InputName("�½�AnimatorController����", ref newAniName);
            GetAnimationObject();
            CreateButton("����", CreateNewController);
            
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

        //��ȡ������Դ��ʽ���пӵ�  
        private void CreateNewController()
        {
            List<AnimationClip> clips = GetAnimationClip();
            if (clips != null && clips.Count > 0)
            {
                generater.Create(aniControllerPath,newAniName, clips);
            }
            else
            {
                Debug.LogError("��ȡ����Ƭ��ʧ�ܣ��޷�����AnimationController");
            }
        }

        /// <summary>
        /// ��ȡ����Ƭ���ļ�
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
                    Close();
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

        public static void Close()
        {
            AssetDatabase.Refresh();
            window.Close();
        }
    }
}
