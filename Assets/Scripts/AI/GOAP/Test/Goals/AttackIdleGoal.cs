using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class AttackIdleGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public AttackIdleGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override GoalEnum Lable { get { return GoalEnum.ATTACK_IDLE; } }

        public override float GetPriority()
        {
            return 20;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.MOVE, true);
            return state;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.ATTACK_IDLE) == true;
        }
    }
}
