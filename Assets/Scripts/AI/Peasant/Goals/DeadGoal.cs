using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class DeadGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label { get { return GoalEnum.DEAD; } }

        public override float GetPriority()
        {
            return 100;
        }

        public DeadGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override IState InitActiveCondition()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_DEAD, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_OVER, true);
            return state;
        }
    }
}
