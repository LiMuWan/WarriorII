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
            AddTrigger(new BodyUpTrigger(_agent));
            AddTrigger(new BodyDownTrigger(_agent));
            AddTrigger(new BodyLeftTrigger(_agent));
            AddTrigger(new BodyRightTrigger(_agent));
        }
    }
}
