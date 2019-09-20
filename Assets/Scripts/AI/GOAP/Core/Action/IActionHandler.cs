﻿using System;
using UnityEngine;

namespace GOAP
{
    public interface IActionHandler<TAction> : IFSMState<TAction>
    {
        IAction<TAction> Action { get; }
        TAction Label { get; }
        bool IsComplete { get; }

        bool CanPerformAction { get; }
        void AddFinishCallBack(Action onFinishAction);
    }

    public abstract class ActionHandlerBase<TAction,TGoal> : IActionHandler<TAction>
    {
        public  IAction<TAction> Action { get; private set; }
        public TAction Label { get { return Action.Label; } }
        public  bool IsComplete { get; private set; }
        public  bool CanPerformAction { get; private set; }
        private Action _onFinishAction;
        protected IAgent<TAction,TGoal> _agent;

        public ActionHandlerBase(IAgent<TAction, TGoal> agent,IAction<TAction> action)
        {
            if (action == null)
                DebugMsg.LogError("动作不能为空");
            Action = action;
            IsComplete = false;
            CanPerformAction = false;
            _agent = agent;
        }

        public  void AddFinishCallBack(Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }

        protected void OnComplete()
        {
            IsComplete = true;
            _onFinishAction?.Invoke();

            SetAgentState(Action.Effects);
            SetAgentState(Action.Preconditions.InversionValue());
        }

        private void SetAgentState(IState state)
        {
            _agent.AgentState.Set(state);
        }

        public void SetAgentState<TKey>(TKey key,bool value)
        {
            _agent.AgentState.Set(key.ToString(), value);
        }

        public virtual void Enter()
        {
            IsComplete = false;
        }

        public virtual void Excute()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}
