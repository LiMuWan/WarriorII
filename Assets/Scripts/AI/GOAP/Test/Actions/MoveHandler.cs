using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class MoveHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;
        private CharacterController _controller;
        private float _speed = 4;

        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入移动状态");
            _self = _agent.Map.GetGameData(DataName.SELF_TRANS) as Transform;
            _enemy = _agent.Map.GetGameData(DataName.ENEMY_TRANS) as Transform;
            _controller = _self.GetComponent<CharacterController>();
        }

        public override void Excute()
        {
            base.Excute();
            if(Vector3.Distance(_self.position,_enemy.position) > 1.5f)
            {
                Vector3 dirToEnemy = (_enemy.position - _self.position).normalized;
                _controller.SimpleMove(dirToEnemy * _speed);
            }
            else
            {
                OnComplete();
                DebugMsg.Log("完成移动状态");
            }
        }
    }
}
