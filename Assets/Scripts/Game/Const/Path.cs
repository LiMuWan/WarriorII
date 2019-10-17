using UnityEngine;

namespace Game
{
    public class Path 
    {
        /// <summary>
        /// Resources 下预制路径
        /// </summary>
        private const string PREFAB_PATH = "Prefabs/";
        /// <summary>
        /// 玩家预制路径
        /// </summary>
        public const string PLAYER_PATH = PREFAB_PATH + "Player";
        /// <summary>
        /// 刀光预制路径
        /// </summary>
        public const string TRAILCOMBO_PATH = PREFAB_PATH + "trails_combo01";

        public const string ENEMY_PATH = "Enemies/";
        public const string PEASANT_DEAD_BODY_HEAD = ENEMY_PATH + "DeadPeasantLowHHead";
    }
}
