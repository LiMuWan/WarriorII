using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class CustomAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public CustomAgent() : base() { }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            throw new System.NotImplementedException();
        }

        protected override DebugBase InitDebugBase()
        {
            throw new System.NotImplementedException();
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            throw new System.NotImplementedException();
        }

        protected override IMap<ActionEnum, GoalEnum> InitMap()
        {
            throw new System.NotImplementedException();
        }

        protected override IState InitState()
        {
            throw new System.NotImplementedException();
        }

        protected override ITriggerManager InitTriggerManager()
        {
            throw new System.NotImplementedException();
        }
    }
}
