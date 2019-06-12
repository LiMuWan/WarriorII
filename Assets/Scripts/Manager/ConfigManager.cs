using System.IO;
using UnityEngine;
using Util;

namespace Game
{
    public class ConfigManager : SingletonBase<ConfigManager>   
    {
        public T LoadJson<T>()
        {
            string json = "";
            if(File.Exists(ConfigPath.PLAYER_CONFIG))
            {
                json = File.ReadAllText(ConfigPath.PLAYER_CONFIG);
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}
