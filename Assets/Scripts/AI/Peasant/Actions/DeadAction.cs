using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class DeadAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 1000; } }
        public override bool CanInterruptiblePlan { get { return true; } }

        private int _priority;
        protected const int DEFAULT_PRIORITY = 1000;

        public DeadAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public void ChangePriority(bool isChange)
        {
            if(isChange)
            {
                _priority = DEFAULT_PRIORITY + 2;
            }
            else
            {
                _priority = DEFAULT_PRIORITY;
            }
        }

        protected override IState InitPreconditions()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_DEAD, true);
            return state;
        }

        protected override IState InitEffects()
        {
            return null;
        }
    }

    public class DeadNormalAction : DeadAction
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }

        public override int Priority { get { return DEFAULT_PRIORITY + 1; } }

        public DeadNormalAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
    }

    public class DeadHeadAction : DeadAction
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_HEAD; } }

        public override int Priority { get { return DEFAULT_PRIORITY + 1; } }

        public DeadHeadAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
    }

    public class DeadBodyAction : DeadAction
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_BODY; } }

        public override int Priority { get { return DEFAULT_PRIORITY + 2; } }

        public DeadBodyAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
    }

    public class DeadLegAction : DeadAction
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_LEG; } }

        public override int Priority { get { return DEFAULT_PRIORITY + 3; } }

        public DeadLegAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
    }
}
