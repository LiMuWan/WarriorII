using UnityEngine;

namespace Game.Interface
{
    /// <summary>
    /// 基础行为接口
    /// </summary>
    public interface IBehaviour
    {
        /// <summary>
        /// 向前转向
        /// </summary>
        void TurnForward();
        /// <summary>
        /// 向后转向
        /// </summary>
        void TurnBack();
        /// <summary>
        /// 向左转向
        /// </summary>
        void TurnLeft();
        /// <summary>
        /// 向右转向
        /// </summary>
        void TurnRight();

        /// <summary>
        /// 移动
        /// </summary>
        void Move();
    }

    /// <summary>
    /// 玩家行为接口
    /// </summary>
    public interface IPlayerBehaviour:IBehaviour
    {
        /// <summary>
        /// 是否正在跑
        /// </summary>
        bool IsRun { get; set;}
        /// <summary>
        /// 是否在攻击
        /// </summary>
        bool IsAttack { get; }
        /// <summary>
        /// 待机
        /// </summary>
        void Idle();

        /// <summary>
        /// 攻击键（按下L)
        /// </summary>
        void Attack(int skillCode);
    }
}
