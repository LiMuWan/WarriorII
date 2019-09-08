using UnityEngine;
using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IActionManager <TAction>
    {
        bool IsPerformAction { get; set; }
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

        bool IActionManager<TAction>.IsPerformAction { get; set; }

        public ActionManagerBase(IAgent<TAction,TGoal> agent)
        {
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
            _agent = agent;
            InitActionHandler();
            InitFSM();
        }

        protected abstract void InitActionHandler();

        private void InitFSM()
        {
            foreach (var handler in _handlerDic)
            {
                _fsm.AddState(handler.Key, handler.Value);
            }
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
            
        }

        public void FrameFun()
        {
            _fsm.FrameFun();
        }


        public void AddActionCompleteListener(Action complete)
        {
            _onActionComplete = complete;
        }

        void IActionManager<TAction>.AddHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        void IActionManager<TAction>.RemoveHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        IActionHandler<TAction> IActionManager<TAction>.GetHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        void IActionManager<TAction>.UpdateData()
        {
            throw new NotImplementedException();
        }

        void IActionManager<TAction>.FrameFun()
        {
            throw new NotImplementedException();
        }

        void IActionManager<TAction>.ChangeCurrentAction(TAction label)
        {
            throw new NotImplementedException();
        }

        void IActionManager<TAction>.AddActionCompleteListener(Action complete)
        {
            throw new NotImplementedException();
        }
    }
}
