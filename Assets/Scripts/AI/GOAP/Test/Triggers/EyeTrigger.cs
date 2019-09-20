using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class EyeTrigger : TriggerBase<ActionEnum, GoalEnum>
    {
        public override bool IsTrigger { get; set; }


        public EyeTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
      
        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY, true);
            return state;
        }
    }
}
