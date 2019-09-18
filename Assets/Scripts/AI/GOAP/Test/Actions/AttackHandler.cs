using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class AttackHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public AttackHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入攻击状态");
            OnComplete();
            DebugMsg.Log("完成攻击状态");
        }
    }
}
