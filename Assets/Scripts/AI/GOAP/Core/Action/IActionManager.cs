using UnityEngine;
using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IActionManager <TAction>
    {
        void AddHandler(TAction label);
        void RemoveHandler(TAction label);
        IActionHandler<TAction> GetHandler(TAction label);
        void UpdateData();
        void FrameFun();
        void ChangeCurrentAction(TAction label);
        void AddActionCompleteListener(Action complete);
    }

    public abstract class ActionManagerBase<TAction> : IActionManager<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _handlerDic;
        private IFSM<TAction> _fsm;

        public ActionManagerBase()
        {
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
        }

        public void AddHandler(TAction label)
        {
            //_handlerDic.Add(label,)
        }

        public void RemoveHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        public IActionHandler<TAction> GetHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentAction(TAction label)
        {
            throw new NotImplementedException();
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }

        public void FrameFun()
        {
            throw new NotImplementedException();
        }


        public void AddActionCompleteListener(Action complete)
        {
            throw new NotImplementedException();
        }
    }
}
