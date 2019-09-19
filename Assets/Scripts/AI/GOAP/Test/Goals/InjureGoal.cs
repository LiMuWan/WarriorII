using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class InjureGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Lable { get { return GoalEnum.INJURE; } }


        public InjureGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override float GetPriority()
        {
            return 100;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.INJURE, false);
            return state;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.INJURE) == true;
        }
    }
}
