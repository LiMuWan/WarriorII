﻿using UnityEngine;

namespace Game
{

    /// <summary>
    /// 相机动画状态名称
    /// </summary>
    public enum CameraAniName
    {
        /// <summary>
        /// 默认
        /// </summary>
        NONE,
        /// <summary>
        /// 相机开场动画
        /// </summary>
        START_GAME_ANI,
        /// <summary>
        /// 相机抖动动画
        /// </summary>
        SHAKE,
    }

    public enum CameraParent
    {
        START,
        IN_GAME
    }

    /// <summary>
    /// 关卡ID
    /// </summary>
    public enum LevelID
    {
        ONE = 1,
        TWO = 2,
    }

    /// <summary>
    /// 关卡大区域ID
    /// </summary>
    public enum LevelGamePartID
    {
        ONE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5
    }

    /// <summary>
    /// 关卡小区域ID
    /// </summary>
    public enum LevelPartID
    {
        ONE = 1,
        TWO = 2,
    }

    /// <summary>
    /// 输入按钮 
    /// </summary>
    public enum InputButton
    {
        NONE,
        FORWARD,
        BACK,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X
    }

    /// <summary>
    /// 输入状态
    /// </summary>
    public enum InputState
    {
        NONE,
        UP,
        PRESS,
        DOWN,
    }

    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum GameState
    {
        START,
        PAUSE,
        END
    }
}
