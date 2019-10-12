﻿using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class MoveHandler : HandlerBase<IModel>
    {
        private Transform _self, _enemy;
        private CharacterController _controller;
        private EnemyData _data;

        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            _self = GetGameData<Transform>(GameDataKeyEnum.SELF_TRANS);
            _enemy = GetGameData<Transform>(GameDataKeyEnum.ENEMY_TRANS);
            _controller = _self.GetComponent<CharacterController>();
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入移动状态");
            _data = GetGameData<EnemyData>(GameDataKeyEnum.CONFIG);
        }

        public override void Execute()
        {
            base.Execute();
            if(Vector3.Distance(_self.position,_enemy.position) <= _data.AttackRange)
            {
                OnComplete(); 
            }
            else
            {
                Vector3 direction = (_enemy.position - _self.position).normalized;
                _controller.SimpleMove(direction * _data.MoveSpeed);
            }
        }
    }
}
