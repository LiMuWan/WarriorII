using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class EyeTrigger : TriggerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;

        public override bool IsTrigger {
            get
            {
                if(Vector3.Distance(_self.position,_enemy.position) < 5)
                {
                    Vector3 dirToEnemy = (_enemy.position - _self.position).normalized;
                    if(Vector3.Angle(_self.forward , dirToEnemy) < 60)
                    {
                        return true;
                    }
                }
                return false;
            }
            set { }
        }


        public EyeTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            _self = agent.Map.GetGameData(DataName.SELF_TRANS) as Transform;
            _enemy = agent.Map.GetGameData(DataName.ENEMY_TRANS) as Transform;
        }
      
        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY, true);
            return state;
        }
    }
}
