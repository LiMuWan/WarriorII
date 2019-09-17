using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IPlannerHandler<TAction>
    {
        bool IsComplete { get; }
        void Init(Queue<IActionHandler<TAction>> plan);
        void StartPlan();
        void NextAction();
        void Interruptible();
    }

    public class PlannerHandler<TAction> : IPlannerHandler<TAction>
    {
        public bool IsComplete { get; private set; }

        public void Init(Queue<IActionHandler<TAction>> plan)
        {
            throw new System.NotImplementedException();
        }

        public void StartPlan()
        {
            throw new System.NotImplementedException();
        }

        public void NextAction()
        {
            throw new System.NotImplementedException();
        }

        public void Interruptible()
        {
            throw new System.NotImplementedException();
        }
    }
}
