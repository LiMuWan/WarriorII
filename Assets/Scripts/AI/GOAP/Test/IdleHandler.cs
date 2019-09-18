using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class IdleHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public IdleHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent,action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("进入待机状态");
        }
    }
}
