using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class TriggerMgr : TriggerManagerBase<ActionEnum, GoalEnum>
    {
        public TriggerMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override void InitTriggers()
        {
            
        }
    }
}
