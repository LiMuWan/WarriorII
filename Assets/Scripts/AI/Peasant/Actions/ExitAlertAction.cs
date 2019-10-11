﻿using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class ExitAlertAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.EXIT_ALERT; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 90; } }
        public override bool CanInterruptiblePlan { get { return false; } }

        public ExitAlertAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override IState InitPreconditions()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_ALERT, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_ALERT, false);
            return state;
        }
    }
}
