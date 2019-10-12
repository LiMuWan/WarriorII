using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class AttackHandler : HandlerBase<AttackModel>
    {
        public AttackHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入攻击状态");
            //todo: 执行动画，播放声音
            OnComplete();
        }
    }
}
