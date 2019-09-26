using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class InjureGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label { get { return GoalEnum.INJURE; } }

        public override float GetPriority()
        {
            return 60;
        }

        public InjureGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override IState InitActiveCondition()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.INJURE, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.INJURE, false);
            return state;
        }
    }
}
