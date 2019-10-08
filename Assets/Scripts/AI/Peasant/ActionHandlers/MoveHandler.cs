using UnityEngine;
using BlueGOAP;
namespace Game.AI
{
    public class MoveHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;
        private CharacterController _controller;

        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入移动状态");
            _self = _agent.Maps.GetGameData(GameDataKeyEnum.SELF_TRANS) as Transform;
            _enemy = _agent.Maps.GetGameData(GameDataKeyEnum.ENEMY_TRANS) as Transform;
            _controller = _self.GetComponent<CharacterController>();
        }

        public override void Execute()
        {
            base.Execute();
            if(Vector3.Distance(_self.position,_enemy.position) <= Const.NEAR_ENEMY_DISTANCE)
            {
                OnComplete(); 
            }
            else
            {
                Vector3 direction = (_enemy.position - _self.position).normalized;
                _controller.SimpleMove(direction * Const.MOVE_VELOCITY);
            }
        }
    }
}
