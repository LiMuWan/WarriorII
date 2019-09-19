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

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.MOVE, true);
            return state;
        }

        protected override bool ActiveCondition()
        {
            return  GetAgentState(KeyNameEnum.MOVE)       == false
                 && GetAgentState(KeyNameEnum.FIND_ENEMY) == true;
        }
    }
}
