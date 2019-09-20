using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class CustomGoalMgr : GoalManagerBase<ActionEnum, GoalEnum>
    {
        public CustomGoalMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override void InitGoals()
        {
            AddGoal(GoalEnum.ALERT);
            AddGoal(GoalEnum.ATTACK);
            AddGoal(GoalEnum.ATTACK_IDLE);
            AddGoal(GoalEnum.INJURE);
        }
    }
}
