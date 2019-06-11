using UnityEngine;

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
        START_GAME_ANI
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
    /// 关卡部分ID
    /// </summary>
    public enum LevelPartID
    {
        ONE = 1,
        TWO
    }

    /// <summary>
    /// 输入按钮 
    /// </summary>
    public enum InputButton
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X
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
