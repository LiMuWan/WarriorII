﻿using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;
using Game.AI.Model;

namespace Game.AI
{
    public class AlertStateHandler : HandlerBase<IModel>
    {
        private Transform _self, _enemy;

        private EnemyData _data;

        public AlertStateHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            _self = GetGameData<Transform>(GameDataKeyEnum.SELF_TRANS);
            _enemy = GetGameData<Transform>(GameDataKeyEnum.ENEMY_TRANS);
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入警戒状态");
            _data = GetGameData<EnemyData>(GameDataKeyEnum.CONFIG);
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
