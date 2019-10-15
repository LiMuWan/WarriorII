using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class InjureAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get; }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 100; } }
        public override bool CanInterruptiblePlan { get { return true; } }

        public InjureAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override IState InitPreconditions()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_INJURE, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_INJURE, false);
            return state;
        }
    }

    public class InjureUpAction : InjureAction
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_UP; } }

        public InjureUpAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class InjureDownAction : InjureAction
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_DOWN; } }

        public InjureDownAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class InjureLeftAction : InjureAction
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_LEFT; } }

        public InjureLeftAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class InjureRightAction : InjureAction
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_RIGHT; } }

        public InjureRightAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }
}
