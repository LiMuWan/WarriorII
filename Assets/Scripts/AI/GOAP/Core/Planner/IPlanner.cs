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
        public Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal)
        {
            
        }
    }
}
