using Game;
using UnityEngine;
using Util;

namespace Manager
{
    /// <summary>
    /// ����ģ�͹�����
    /// </summary>
    public class ModelManager : SingletonBase<ModelManager>   
    {
        /// <summary>
        /// �������������
        /// </summary>
        public PlayerDataModel PlayerData{ get; private set; }
        public void Init()        
        {
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>();
        }
    }
}
