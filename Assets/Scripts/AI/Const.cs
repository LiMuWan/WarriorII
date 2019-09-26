using UnityEngine;

namespace Game.AI
{
    public class Const     
    {
        /// <summary>
        /// 攻击待机的延时时间
        /// </summary>
        public const float IDLE_SWORD_DELAY_TIME = 2f;

        /// <summary>
        /// 接近敌人的可攻击距离
        /// </summary>
        public const float NEAR_ENEMY_DISTANCE = 1.5f;

        /// <summary>
        /// 安全距离
        /// </summary>
        public const float SAFE_DISTANCE = 5;

        /// <summary>
        /// 发现目标距离
        /// </summary>
        public const float FIND_ENEMY_DISTANCE = 20;

        /// <summary>
        /// 自身视线范围
        /// </summary>
        public const float SIGHT_LINE_RANGE = 60;

        /// <summary>
        /// 移动速度
        /// </summary>
        public const float MOVE_VELOCITY = 1.5f;

        /// <summary>
        /// 一击必杀伤害数值
        /// </summary>
        public const int INSTANT_KILL = 1000;
    }
}
