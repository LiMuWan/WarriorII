using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IPlanner<TAction,TGoal>
    {
        Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
    }

    public class Planner<TAction, TGoal> : IPlanner<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> _agent;

        public Planner(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
        }

        public Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal)
        {
            Queue<IActionHandler<TAction>> plan = new Queue<IActionHandler<TAction>>();

            if (goal == null)
                return plan;

            TreeNode<TAction> currentNode = Plan(goal);
            if(currentNode == null)
            {

            }
        }

        private TreeNode<TAction> Plan(IGoal<TGoal> goal)
        {

        }
    }
}
