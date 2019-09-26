using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class AttackGoal: GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label { get { return GoalEnum.ATTACK; } }

        public AttackGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override float GetPriority()
        {
            return 40;
        }

        protected override IState InitActiveCondition()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.FIND_ENEMY, true);
            state.Set(StateKeyEnum.MOVE, false);
            state.Set(StateKeyEnum.STEP_BACK, false);
            return state;
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.ALERT, true);
            state.Set(StateKeyEnum.ATTACK, false);
            state.Set(StateKeyEnum.MOVE, false);
            return state;
        }
    }
}
