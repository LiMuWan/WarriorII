using UnityEngine;

namespace GOAP
{
    public interface IPerform
    {
        void UpdateData();
        void Interruptible();
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
            _actionManager.AddActionCompleteListener(PlanActionComplete);
        }

        public void Interruptible()
        {
            _plannerHandler.Interruptible();
        }

        private void PlanComplete()
        {
            DebugMsg.Log("计划执行完毕");
            _actionManager.IsPerformAction = false;
        }

        private void PlanActionComplete()
        {
            DebugMsg.Log("下一步");
            _plannerHandler.NextAction();
        }

        public void UpdateData()
        {
            if(WhetherToReplan())
            {
                DebugMsg.Log("制定计划");
                BuildAndStartPlan(); 
            }
        }

        private bool WhetherToReplan()
        {
            return _plannerHandler.IsComplete;
        }

        private void BuildAndStartPlan()
        {
            var plan = _planner.BuildPlan(_goalManager.Current);

            if(plan != null && plan.Count > 0)
            {
                _plannerHandler.Init(_actionManager, plan);
                _plannerHandler.StartPlan();
                _actionManager.IsPerformAction = true;
            }
        }
    }
}
