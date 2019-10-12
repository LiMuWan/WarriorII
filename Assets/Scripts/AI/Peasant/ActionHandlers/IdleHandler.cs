using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class IdleHandler : HandlerBase<IModel>
    {
        public IdleHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            IsNeedResetPreconditions = false;
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入待机状态");
        }

        public override void Execute()
        {
            base.Execute();

            if(_agent.AgentState.Get(StateKeyEnum.FIND_ENEMY.ToString()) == true)
            {
                OnComplete();
            }
        }
    }
}
