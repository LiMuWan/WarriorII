using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class PeasantGoalMgr : GoalManagerBase<ActionEnum, GoalEnum>
    {
        public PeasantGoalMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        protected override void InitGoals()
        {
            AddGoal(GoalEnum.ATTACK);
            AddGoal(GoalEnum.DEAD);
            AddGoal(GoalEnum.IDLE_SWORD);
            AddGoal(GoalEnum.INJURE);
        }
    }
}
