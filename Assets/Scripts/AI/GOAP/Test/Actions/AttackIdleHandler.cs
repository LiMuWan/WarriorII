using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class AttackIdleHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private float _time;

        public AttackIdleHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入战斗待机状态");
            _time = 0;
        }

        public override void Excute()
        {
            base.Excute();
            if(_time < 2)
            {
                _time += Time.fixedDeltaTime;
            }
            else
            {
                OnComplete();
                DebugMsg.Log("完成战斗待机状态");
            }
        }
    }
}
