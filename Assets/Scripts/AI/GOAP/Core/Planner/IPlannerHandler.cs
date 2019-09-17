using System;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IPlannerHandler<TAction>
    {
        bool IsComplete { get; }
        void Init(IActionManager<TAction> actionManager, Queue<IActionHandler<TAction>> plan);
        void StartPlan();
        void NextAction();
        void Interruptible();
        void AddCompleteCallBack(Action onComplete);
    }

    public class PlannerHandler<TAction> : IPlannerHandler<TAction>
    {
        public bool IsComplete
        {
            get
            {
                if (_isInterruptible)
                    return true;

                if (_plan == null)
                    return true;

                if(_currentActionHandler == null)
                {
                    return _plan.Count == 0;
                }
                else
                {
                    return _currentActionHandler.IsComplete && _plan.Count == 0;
                }
            }
        }

        private Action _onComplete;

        private Queue<IActionHandler<TAction>> _plan;
        private IActionHandler<TAction> _currentActionHandler;
        private IActionManager<TAction> _actionManager;
        private bool _isInterruptible;

        public void Init(IActionManager<TAction> actionManager,Queue<IActionHandler<TAction>> plan)
        {
            _plan = plan;
            _actionManager = actionManager;
            _currentActionHandler = null;
            _onComplete = null;
            _isInterruptible = false;
        }

        public void StartPlan()
        {
            NextAction();
        }

        public void NextAction()
        {
           if(IsComplete)
            {
                _onComplete?.Invoke();
            }
           else
            {
                _currentActionHandler = _plan.Dequeue();
                _actionManager.ChangeCurrentAction(_currentActionHandler.Label);
            }
        }

        public void Interruptible()
        {
            _isInterruptible = true;
        }

        public void AddCompleteCallBack(Action onComplete)
        {
            _onComplete = onComplete;
        }
    }
}
