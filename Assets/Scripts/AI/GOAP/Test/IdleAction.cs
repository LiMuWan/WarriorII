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

        public IdleAction(IAgent<ActionEnum,GoalEnum> agent):base(agent)
        {

        }

        protected override IState InitEffects()
        {
            throw new System.NotImplementedException();
        }

        protected override IState InitPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
