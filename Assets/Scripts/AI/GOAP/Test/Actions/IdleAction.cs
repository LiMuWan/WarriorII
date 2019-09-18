using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class IdleAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE; } }

        public override int Cost { get { return 1; } }

        public override int Priority { get { return 0; } }

        public override bool CanInterruptiblePlan { get { return false; } }

        public IdleAction(IAgent<ActionEnum,GoalEnum> agent) : base(agent)
        {

        }

        protected override IState InitEffects()
        {
            return null;
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.IDLE, false);
            state.Set(KeyNameEnum.ATTACK, false);
            state.Set(KeyNameEnum.MOVE, false);

            return state;

        }
    }
}
