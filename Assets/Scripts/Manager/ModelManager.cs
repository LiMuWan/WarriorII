﻿using Game;
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

        /// <summary>
        /// 敌人配置
        /// </summary>
        public EnemyModel EnemyModel { get; private set; }

        /// <summary>
        /// 敌人生成配置类
        /// </summary>
        public SpawEnemyModel SpawEnemyModel { get; private set; }

        public void Init()        
        {
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>(Const.ConfigPath.PLAYER_CONFIG);
            HumanSkillDataModel = ConfigManager.Single.LoadJson<HumanSkillDataModel>(Const.ConfigPath.HUMAN_SKILL_CONFIG);
            EnemyModel = ConfigManager.Single.LoadJson<EnemyModel>(Const.ConfigPath.ENEMY_CONFIG);
            SpawEnemyModel = ConfigManager.Single.LoadJson<SpawEnemyModel>(Const.ConfigPath.SPAW_ENEMY_CONFIG);
        }
    }
}
