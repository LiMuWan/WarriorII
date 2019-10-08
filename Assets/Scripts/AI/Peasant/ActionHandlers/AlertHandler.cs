using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class AlertHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;

        private EnemyData data;

        public AlertHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入警戒状态");
            _self = GetGameData(GameDataKeyEnum.SELF_TRANS) as Transform;
            _enemy = GetGameData(GameDataKeyEnum.ENEMY_TRANS) as Transform;
            data = GetGameData(GameDataKeyEnum.CONFIG) as EnemyData;
        }

        public override void Execute()
        {
            base.Execute();
            if(data.Life > 0 && _agent.AgentState.ContainState(Action.Preconditions))
            {
                _self.LookAt(_enemy);
            }
            else
            {
                OnComplete();
            }
        }
    }
}
