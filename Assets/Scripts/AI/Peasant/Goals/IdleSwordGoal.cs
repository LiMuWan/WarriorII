using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class IdleSwordGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label { get { return GoalEnum.IDLE_SWORD; } }

        public IdleSwordGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override float GetPriority()
        {
            return 0;
        }

        protected override IState InitActiveCondition()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.ALERT, true);
            state.Set(StateKeyEnum.CAN_ATTACK, false);
            state.Set(StateKeyEnum.CAN_MOVE_FORWARD, false);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.CAN_MOVE_FORWARD, true);
            return state;
        }
    }
}
