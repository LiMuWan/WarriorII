using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    public class GenerateCode
    {
        /// <summary>
        /// 自动创建类名为classNamed的脚本，并填充脚本内容为scriptContent
        /// </summary>
        /// <param name="path"></param>
        /// <param name="className"></param>
        /// <param name="scriptContent"></param>
        public static void CreateScript(string path, string className, string scriptContent)
        {
            if (Directory.Exists(path))
            {
                File.WriteAllText(path + "/" + className + ".cs", scriptContent);
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogError("目录：" + path + "不存在！");
            }
        }

        /// <summary>
        /// 自动添加Services初始化代码
        /// </summary>
        /// <param name="path"></param>
        public static void InitServices(string path)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                int index = content.IndexOf("IInitService[] services =");
                int newIndex = content.IndexOf("new", index);
                content = content.Insert(newIndex, "new" + " " + ToolData.serviceName + ToolData.servicePostfix + "(), \r                   ");
                File.WriteAllText(path, content, Encoding.UTF8);

                GenerateEntitasCodeWindow.Close();
            }
            else
            {
                Debug.LogError("ServiceManager 脚本不存在！");
            }
        }

        /// <summary>
        /// 自动添加System系统部分初始化代码
        /// </summary>
        /// <param name="contentName"></param>
        /// <param name="className"></param>
        /// <param name="systemName"></param>
        public static void InitSystem(string contentName, string className, params string[] systemName)
        {
            string path = "";
            switch (contentName)
            {
                case "Game":
                    path = ToolData.gameFeaturePath;
                    break;
                case "Input":
                    path = ToolData.inputFeaturePath;
                    break;
            }

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            foreach (string name in systemName)
            {
                SetSystem(path, name, className);
            }
            GenerateEntitasCodeWindow.Close();
        }

        /// <summary>
        /// 根据上下文和System类名，得到对应的System管理类，自动添加Class的初始化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="systemName"></param>
        /// <param name="className"></param>
        public static void SetSystem(string path, string systemName, string className)
        {
            string content = File.ReadAllText(path);
            int index = content.IndexOf("void " + systemName + "Fun(Contexts contexts)");
            if (index < 0)
            {
                Debug.LogError("未找到对应方法，系统名：" + systemName);
                return;
            }
            int startIndex = content.IndexOf("{", index);
            content = content.Insert(startIndex + 1, "\r            Add(new " + className + "(contexts)); ");
            File.WriteAllText(path, content, Encoding.UTF8);
        }
    }
}
