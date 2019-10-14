using BlueGOAP;
using UnityEngine;

namespace Game.AI
{
    public abstract class BodyTrigger : TriggerBase
    {
        public BodyTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class BodyUpTrigger : BodyTrigger
    {
        public override int Priority { get;}

        public override bool IsTrigger { get; set; }

        public BodyUpTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitEffects()
        {
            return new State();
        }
    }
}
