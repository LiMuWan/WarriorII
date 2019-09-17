using UnityEngine;

namespace GOAP
{
    public interface ITrigger
    {
       bool IsTrigger { get; set; }
       void FrameFun();
    }

    public abstract class TriggerBase<TAction, TGoal> :ITrigger
    {
        public abstract bool IsTrigger { get; set; }

        private IAgent<TAction, TGoal> _agent;
        private IState _effects;

        public TriggerBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _effects = InitEffects();
        }

        protected abstract IState InitEffects();

        public void FrameFun()
        {
            if(IsTrigger)
            {
                _agent.AgentState.Set(_effects);
            }
        }
    }
}
