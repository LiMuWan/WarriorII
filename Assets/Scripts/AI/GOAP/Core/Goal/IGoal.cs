using System;
using UnityEngine;

namespace GOAP
{
    public interface IGoal<TGoal>
    {
        TGoal Lable { get;}

        float GetPriority();

        IState GetEffects();

        bool IsGoalComplete();

        void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate);

        void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate);

        void UpdateData();
    }

    public abstract class GoalBase<TAction,TGoal> : IGoal<TGoal>
    {
        public abstract TGoal Lable { get; }

        private Action<IGoal<TGoal>> _onActivate;

        private Action<IGoal<TGoal>> _onInactivate;

        private IState _effects;

        private IAgent<TAction, TGoal> _agent;

        public GoalBase(IAgent<TAction,TGoal> agent)
        {
            _agent = agent;
            _effects = InitEffects();
        }

        public abstract float GetPriority();

        public IState GetEffects()
        {
            return _effects;
        }

        protected abstract IState InitEffects();

        protected abstract bool ActiveCondition();

        public virtual bool IsGoalComplete()
        {
            return _agent.AgentState.ContainState(_effects);
        }

        public bool GetAgentState<TKey>(TKey key)
        {
            return _agent.AgentState.ContainsKey(key.ToString());
        }

        public void UpdateData()
        {
            if(ActiveCondition())
            {
                _onActivate(this);
            }
            else
            {
                _onInactivate(this);
            }
        }

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            _onActivate = onActivate;
        }

        public void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate)
        {
            _onInactivate = onInactivate;
        }
    }
}
