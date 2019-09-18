using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class MoveAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }

        public override int Cost { get { return 5; } }

        public override int Priority { get { return 70; } }

        public override bool CanInterruptiblePlan { get; }

        public MoveAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.NEAR_ENEMY, true);
            return state;
        }

    }
}
