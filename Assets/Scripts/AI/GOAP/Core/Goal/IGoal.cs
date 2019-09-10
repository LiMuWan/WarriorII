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

    public abstract class GoalBase<TGoal> : IGoal<TGoal>
    {
        public abstract TGoal Lable { get; set; }

        private Action<IGoal<TGoal>> _onActivate;

        private Action<IGoal<TGoal>> _onInactivate;

        public abstract float GetPriority();

        public abstract IState GetEffects();

        public abstract bool ActiveCondition();

        public abstract bool IsGoalComplete();

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
            _onInactivate = _onInactivate;
        }
    }
}
