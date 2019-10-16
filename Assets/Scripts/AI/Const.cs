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
        /// 自身视线范围
        /// </summary>
        public const float SIGHT_LINE_RANGE = 60;

        /// <summary>
        /// 一击必杀伤害数值
        /// </summary>
        public const int INSTANT_KILL = 1000;

        /// <summary>
        /// 身体各部分的角度范围
        /// </summary>
        public const int BODY_PART_RANGE = 30;

        public const int HEAD_SCALE = 1;
        public const int BODY_SCALE = 2;
        public const int LEG_SCALE = 2;
        public const int ALL_BODY_SACLE = HEAD_SCALE + BODY_SCALE + LEG_SCALE;
    }
}
