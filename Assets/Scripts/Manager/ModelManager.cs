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

        /// <summary>
        /// 玩家技能数据配置类
        /// </summary>
        public HumanSkillDataModel HumanSkillDataModel { get; private set; }

        public void Init()        
        {
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>(Const.ConfigPath.PLAYER_CONFIG);
            HumanSkillDataModel = ConfigManager.Single.LoadJson<HumanSkillDataModel>(Const.ConfigPath.HUMAN_SKILL_CONFIG);
            Debug.Log(HumanSkillDataModel.Skills[0].Code[0]);
        }
    }
}
