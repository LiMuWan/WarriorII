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

        public TriggerManagerBase()
        {
            _triggers = new HashSet<ITrigger>();
            InitTriggers();
        }

        public abstract void InitTriggers();

        public void FrameFun()
        {
            
        }
    }
}
