using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class AlertHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;

        private EnemyData _data;
        private AlertModel _model;

        public AlertHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            AIModelMgr mgr = GetGameData<GameDataKeyEnum, AIModelMgr>(GameDataKeyEnum.AI_MODEL_MANAGER);
            _model = mgr.GetModel(ActionEnum.ALERT) as AlertModel;
            if(_model == null)
            {
                DebugMsg.LogError("获取" + Action.Label + "的数据类型失败");
            }
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入警戒状态");
            _self = GetGameData<GameDataKeyEnum,Transform>(GameDataKeyEnum.SELF_TRANS);
            _enemy = GetGameData<GameDataKeyEnum,Transform>(GameDataKeyEnum.ENEMY_TRANS);
            _data = GetGameData<GameDataKeyEnum,EnemyData>(GameDataKeyEnum.CONFIG);
        }

        public override void Execute()
        {
            base.Execute();
            if(_data.Life > 0 && _agent.AgentState.ContainState(Action.Preconditions))
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
