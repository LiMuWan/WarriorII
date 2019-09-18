using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class MoveHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;

        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入移动状态");
            _self = _agent.Map.GetGameData(DataName.SELF_TRANS) as Transform;
            _enemy = _agent.Map.GetGameData(DataName.ENEMY_TRANS) as Transform;
        }
    }
}
