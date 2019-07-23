using Const;
using System.IO;
using UnityEngine;
using Util;

namespace Manager
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager : SingletonBase<ConfigManager>   
    {
        /// <summary>
        /// 加载json配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T LoadJson<T>(string path)
        {
            string json = "";
            if(File.Exists(path))
            {
                json = File.ReadAllText(path);
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}
