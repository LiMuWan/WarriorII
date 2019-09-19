using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class AlertGoal : GoalBase<ActionEnum,GoalEnum>
    {
        public AlertGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override GoalEnum Lable { get { return GoalEnum.ALERT; } }

        public override float GetPriority()
        {
            return 1;
        }

        public override IState GetEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.MOVE, true);
            return state;
        }

        public override bool ActiveCondition()
        {
           
        }

        public override IState InitEffects()
        {
            
        }
    }
}
