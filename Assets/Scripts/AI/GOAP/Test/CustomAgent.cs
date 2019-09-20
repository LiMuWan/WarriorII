using System;
using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class CustomAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public CustomAgent() : base() { }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            return new CurrentActMgr(this);
        }

        protected override DebugBase InitDebugBase()
        {
            return new CustomDebug();
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            return new CustomGoalMgr(this);
        }

        protected override IMap<ActionEnum, GoalEnum> InitMap()
        {
            return new CustomMap(this);
        }

        protected override IState InitState()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            foreach (KeyNameEnum key in Enum.GetValues(typeof(KeyNameEnum)))
            {
                state.Set(key, false);
            }

            state.Set(KeyNameEnum.IDLE, true);

            return state;
        }

        protected override ITriggerManager InitTriggerManager()
        {
            return new TriggerMgr(this);
        }
    }
}
