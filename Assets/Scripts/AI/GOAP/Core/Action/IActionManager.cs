﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public interface IActionManager <TAction>
    {
        Dictionary<string, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; }
        bool IsPerformAction { get; set; }
        TAction GetDefaultActionLable();
        void AddHandler(TAction label);
        void RemoveHandler(TAction label);
        IActionHandler<TAction> GetHandler(TAction label);
        void UpdateData();
        void FrameFun();
        void ChangeCurrentAction(TAction label);
        void AddActionCompleteListener(Action complete);
    }

    public abstract class ActionManagerBase<TAction,TGoal> : IActionManager<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _handlerDic;
        private IFSM<TAction> _fsm;
        private IAgent<TAction, TGoal> _agent;
        private Action _onActionComplete;
        private List<IActionHandler<TAction>> _InterruptibleHandlers;

        public  bool  IsPerformAction { get; set; }

        public Dictionary<string, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; private set; }

        public ActionManagerBase(IAgent<TAction,TGoal> agent)
        {
            IsPerformAction = false;
            _onActionComplete = null;
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _InterruptibleHandlers = new List<IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
            _agent = agent;
            InitActionHandler();
            InitFSM();
            InitInterruptibleHandlers();
            InitEffectsAndActionMap();
        }

        protected abstract void InitActionHandler();

        public abstract TAction GetDefaultActionLable();

        private void InitFSM()
        {
            foreach (var handler in _handlerDic)
            {
                _fsm.AddState(handler.Key, handler.Value);
            }
        }

        private void InitEffectsAndActionMap()
        {
            EffectsAndActionMap = new Dictionary<string, HashSet<IActionHandler<TAction>>>();

            foreach (KeyValuePair<TAction,IActionHandler<TAction>> pair in _handlerDic)
            {
                IState state = pair.Value.Action.Effects;

                if (state == null)
                    continue;

                foreach (string key in state.GetKeys())
                {

                }
            }
        }

        private void InitInterruptibleHandlers()
        {
            foreach (KeyValuePair<TAction, IActionHandler<TAction>> handler in _handlerDic)
            {
                if(handler.Value.Action.CanInterruptiblePlan)
                {
                    _InterruptibleHandlers.Add(handler.Value);
                }
            }
            _InterruptibleHandlers = _InterruptibleHandlers.OrderByDescending(u => u.Action.Priority).ToList();
        }

        public void AddHandler(TAction label)
        {
            var handler = _agent.Map.GetActionHandler(label);
            if(handler != null)
            {
                _handlerDic.Add(label,handler);
                handler.AddFinishCallBack(() => _onActionComplete());
            }
            else
            {
                DebugMsg.LogError("映射文件中未找到对应Handler，标签为： " + label);
            }
            
        }

        public void RemoveHandler(TAction label)
        {
            _handlerDic.Remove(label);
        }

        public IActionHandler<TAction> GetHandler(TAction label)
        {
            if(_handlerDic.ContainsKey(label))
            {
                return _handlerDic[label];
            }
            else
            {
                DebugMsg.LogError("缓存中未找到对应handler,标签为 ： " + label);
                return null;
            }
        }

        public void ChangeCurrentAction(TAction label)
        {
            _fsm.ChangeState(label);
        }

        public void UpdateData()
        {
            foreach (var handler in _InterruptibleHandlers)
            {
                if(handler.CanPerformAction)
                { 
                    _agent.Perform.Interruptible();
                    break;
                }
            }
        }

        public void FrameFun()
        {
            _fsm.FrameFun();
        }

        public void AddActionCompleteListener(Action complete)
        {
            _onActionComplete = complete;
        }
    }
}
