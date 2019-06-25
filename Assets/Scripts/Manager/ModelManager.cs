using Game;
using UnityEngine;
using Util;

namespace Manager
{
    /// <summary>
    /// 数据模型管理类
    /// </summary>
    public class ModelManager : SingletonBase<ModelManager>   
    {
        /// <summary>
        /// 玩家数据配置类
        /// </summary>
        public PlayerDataModel PlayerData{ get; private set; }
        public void Init()        
        {
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>();
        }
    }
}
