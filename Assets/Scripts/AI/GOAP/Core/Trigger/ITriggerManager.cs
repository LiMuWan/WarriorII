using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface ITriggerManager
    {
        void FrameFun();
    }

    public abstract class TriggerManagerBase<TAction,TGoal> : ITriggerManager
    {
        private HashSet<ITrigger> _triggers;
        protected IAgent<TAction, TGoal> _agent;


        public TriggerManagerBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _triggers = new HashSet<ITrigger>();
            InitTriggers();
        }

        protected abstract void InitTriggers();

        protected void AddTrigger(ITrigger trigger)
        {
            _triggers.Add(trigger);
        }

        public void FrameFun()
        {
            foreach (var trigger in _triggers)
            {
                trigger.FrameFun();
            }
        }
    }
}
