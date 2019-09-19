using GOAP;

namespace GOAPTest
{
    public class AttackGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public AttackGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override GoalEnum Lable { get { return GoalEnum.ATTACK; } }

        public override float GetPriority()
        {
            return 40;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.ATTACK_IDLE, true);
            return state;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.FIND_ENEMY)  == true
                && GetAgentState(KeyNameEnum.ATTACK_IDLE) == false;
        }
    }
}
