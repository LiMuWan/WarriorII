using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class PeasantTriggerMgr : TriggerManagerBase<ActionEnum, GoalEnum>
    {
        public PeasantTriggerMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override void InitTriggers()
        {
            AddTrigger(new EyesTrigger(_agent));
        }
    }
}
