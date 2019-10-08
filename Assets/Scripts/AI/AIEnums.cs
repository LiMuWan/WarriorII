﻿using UnityEngine;

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
        /// <summary>
        /// 是否发现目标
        /// </summary>
        FIND_ENEMY,
        /// <summary>
        /// 是否到达目标身边
        /// </summary>
        NEAR_ENEMY,
        /// <summary>
        /// 是否可以攻击
        /// </summary>
        CAN_ATTACK,
        /// <summary>
        /// 是否受伤
        /// </summary>
        IS_INJURE,
        /// <summary>
        /// 是否死亡
        /// </summary>
        IS_DEAD,
        /// <summary>
        /// 是否能够移动
        /// </summary>
        CAN_MOVE_FORWARD,
        /// <summary>
        /// 是否在安全距离
        /// </summary>
        IS_SAFE_DISTANCE
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
