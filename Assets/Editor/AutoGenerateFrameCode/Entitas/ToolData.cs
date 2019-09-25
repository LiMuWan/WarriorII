using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    public class ToolData
    {
        /// <summary>
        /// View 文件夹路径
        /// </summary>
        public static string viewPath;
        /// <summary>
        /// Service 文件夹路径
        /// </summary>
        public static string servicePath;
        /// <summary>
        /// System 文件夹路径
        /// </summary>
        public static string systemPath;
        /// <summary>
        /// ServiceManager类路径
        /// </summary>
        public static string serviceManagerPath;
        /// <summary>
        /// GameFeature类路径
        /// </summary>
        public static string gameFeaturePath;
        /// <summary>
        /// InputFeature类路径
        /// </summary>
        public static string inputFeaturePath;
        /// <summary>
        /// ViewFeature类路径
        /// </summary>
        public static string viewFeaturePath;
        /// <summary>
        /// 持久化数据文件所在路径
        /// </summary>
        public static string dataPath = "Assets/Editor/AutoGenerateFrameCode/Data/";
        /// <summary>
        /// 持久化文件名称
        /// </summary>
        public static string dataFileName = "EntitasData.asset";
        /// <summary>
        /// View 层类的名字后缀
        /// </summary>
        public static string viewPostfix = "View";
        /// <summary>
        /// 输入框中的View类名称
        /// </summary>
        public static string viewName;
        /// <summary>
        /// Service 层类的名字后缀
        /// </summary>
        public static string servicePostfix = "Service";
        /// <summary>
        /// 输入框中的Service类名称
        /// </summary>
        public static string serviceName;
        /// <summary>
        /// System 层类的名字后缀
        /// </summary>
        public static string systemPosfix = "System";
        /// <summary>
        /// 输入框中的System类名称
        /// </summary>
        public static string systemName;
        /// <summary>
        /// 基础的命名空间名称
        /// </summary>
        public static string namespaceBase = "Game";
        /// <summary>
        /// 所有上下文名称缓存
        /// </summary>
        public static string[] contextNames;
        /// <summary>
        /// 上下文选中状态的缓存
        /// </summary>
        public static Dictionary<string, bool> contextSelectedStateDic;
        /// <summary>
        /// 当前选中的上下文名称
        /// </summary>
        public static string selectedContextName;
        /// <summary>
        /// 输入框中其他系统类名称
        /// </summary>
        public static string otherSystemName;

        /// <summary>
        /// 所有system类可以继承的Entitas接口
        /// </summary>
        public static string[] systemInterfaceNames =
        {
            "IInitializeSystem",
            "IExecuteSystem",
            "ICleanupSystem",
            "ITearDownSystem"
        };

        /// <summary>
        /// 系统选中状态的缓存
        /// </summary>
        public static Dictionary<string, bool> systemSelectedStateDic;
        /// <summary>
        /// 换行间距
        /// </summary>
        public static int lineSpace;

        /// <summary>
        /// 数据初始化
        /// </summary>
        public static void Init()
        {
            lineSpace = 15;
            ReadDataFromLocal();
            GetContextName();
            InitContextSelectdState();
            selectedContextName = contextNames[0];
            InitSystemSelectdState();
        }

        #region ContextSelectedState
        /// <summary>
        /// 初始化上下文选中状态
        /// </summary>
        public static void InitContextSelectdState()
        {
            contextSelectedStateDic = new Dictionary<string, bool>();
            ResetContextSelectedState();
        }

        /// <summary>
        /// 重置上下文选中状态为未选中
        /// </summary>
        public static void ResetContextSelectedState()
        {
            foreach (string contextName in contextNames)
            {
                contextSelectedStateDic[contextName] = false;
            }
        }
        #endregion

        #region SystemSelectedState
        /// <summary>
        /// 初始化System选中状态
        /// </summary>
        public static void InitSystemSelectdState()
        {
            systemSelectedStateDic = new Dictionary<string, bool>();
            ResetSystemSelectedState();
        }

        /// <summary>
        /// 重置选中的selectedSystem状态为未选中
        /// </summary>
        public static void ResetSystemSelectedState()
        {
            foreach (string systemName in systemInterfaceNames)
            {
                systemSelectedStateDic[systemName] = false;
            }
        }
        #endregion

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public static void SaveDataToLocal()
        {
            Directory.CreateDirectory(dataPath);
            EntitasData data = new EntitasData();
            data.ViewPath = viewPath;
            data.ServicePath = servicePath;
            data.SystemPath = systemPath;
            data.ServiceManagerPath = serviceManagerPath;
            data.GameFeaturePath = gameFeaturePath;
            data.InputFeaturePath = inputFeaturePath;
            data.ViewFeaturePath = viewFeaturePath;
            AssetDatabase.CreateAsset(data, dataPath + dataFileName);
        }

        /// <summary>
        /// 从本地读取数据
        /// </summary>
        public static void ReadDataFromLocal()
        {
            EntitasData data = AssetDatabase.LoadAssetAtPath<EntitasData>(dataPath + dataFileName);
            if (data != null)
            {
                viewPath = data.ViewPath;
                servicePath = data.ServicePath;
                systemPath = data.SystemPath;
                serviceManagerPath = data.ServiceManagerPath;
                gameFeaturePath = data.GameFeaturePath;
                inputFeaturePath = data.InputFeaturePath;
                viewFeaturePath = data.ViewFeaturePath;
            }
        }

        /// <summary>
        /// 获取上下文context名字
        /// </summary>
        public static void GetContextName()
        {
            var provider = new ContextDataProvider();
            provider.Configure(Preferences.sharedInstance);
            var data = (ContextData[])provider.GetData();
            contextNames = data.Select(p => p.GetContextName()).ToArray();
        }
    }
}
