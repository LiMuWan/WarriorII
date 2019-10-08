using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class EyesTrigger : TriggerBase<ActionEnum, GoalEnum>
    {
        public override int Priority { get { return 1; } }
        public override bool IsTrigger {
            get
            {
                if(_self == null || _enemy == null)
                {
                    _self = _agent.Maps.GetGameData(GameDataKeyEnum.SELF_TRANS) as Transform;
                    _enemy = _agent.Maps.GetGameData(GameDataKeyEnum.ENEMY_TRANS) as Transform;
                }

                if(_enemy == null ||  _self == null)
                    return false;

                EnemyData data = _agent.Maps.GetGameData(GameDataKeyEnum.CONFIG) as EnemyData;

                //比对发现目标的距离
                if(Vector3.Distance(_self.position,_enemy.position) < data.FindDistance)
                {
                    //查看是否再视线角度内
                    Vector3 dirToEnemy = (_enemy.position - _self.position).normalized;

                    if(Vector3.Angle(_self.forward,dirToEnemy) < Const.SIGHT_LINE_RANGE)
                    {
                        return true;
                    }
                }

                return false;
            }
            set { }
        }

        private Transform _self, _enemy;

        public EyesTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.FIND_ENEMY, true);
            return state;
        }
    }
}
