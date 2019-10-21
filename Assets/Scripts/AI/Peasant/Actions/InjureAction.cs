using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class InjureAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get; }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return _priority; } }
        public override bool CanInterruptiblePlan { get { return true; } }

        private int _priority;
        private const int DEFAULT_PRIORITY = 100;

        public InjureAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            _priority = DEFAULT_PRIORITY;
        }

        public void ChangePriority(bool isChange)
        {
            if(isChange)
            {
                _priority = DEFAULT_PRIORITY + 1;
            }
            else
            {
                _priority = DEFAULT_PRIORITY;
            }
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
