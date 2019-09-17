using UnityEngine;

namespace GOAP
{
    public interface IPerform
    {
        void UpdateData();
    }

    public class Performer<TAction, TGoal> : IPerform
    {
        private IPlannerHandler<TAction> _plannerHandler;
        private IPlanner<TAction, TGoal> _planner;
        private IGoalManager<TGoal> _goalManager;
        private IActionManager<TAction> _actionManager;

        public Performer(IAgent<TAction,TGoal> agent)
        {
            _plannerHandler = new PlannerHandler<TAction>();
            _plannerHandler.AddCompleteCallBack(PlanComplete);

            _planner = new Planner<TAction, TGoal>(agent);
            _goalManager = agent.GoalManager;
            _actionManager = agent.ActionManager;
        }

        private void PlanComplete()
        {

        }

        public void UpdateData()
        {

        }
    }
}
