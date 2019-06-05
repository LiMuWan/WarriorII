using UnityEngine;

namespace Game
{

    /// <summary>
    /// 相机动画状态名称
    /// </summary>
    public enum CameraAniName
    {
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
}
