using UnityEngine;

namespace Game.AI
{
    /// <summary>
    /// 动作
    /// </summary>
    public enum ActionEnum
    {
        ALERT,
        IDLE,
        IDLE_SWORD,
        ATTACK,
        INJURE,
        DEAD,
        MOVE,
        MoveBackward
    }

    /// <summary>
    /// 目标
    /// </summary>
    public enum GoalEnum
    {
        IDLE_SWORD,
        ATTACK,
        INJURE,
        DEAD
    }

    /// <summary>
    /// 状态键值
    /// </summary>
    public enum StateKeyEnum
    {
        ALERT,
        FIND_ENEMY,
        NEAR_ENEMY,
        ATTACK,
        INJURE,
        DEAD,
        MOVE,
        /// <summary>
        /// 后退
        /// </summary>
        STEP_BACK
    }

    /// <summary>
    /// 游戏数据键值
    /// </summary>
    public enum GameDataKeyEnum
    {
        /// <summary>
        /// 敌方单位对象
        /// </summary>
        ENEMY_TRANS,
        /// <summary>
        /// 自身对象
        /// </summary>
        SELF_TRANS,
        /// <summary>
        /// 受伤值
        /// </summary>
        INJURE_VALUE,
        /// <summary>
        /// 此单位的基础配置文件
        /// </summary>
        CONFIG
    }
}
