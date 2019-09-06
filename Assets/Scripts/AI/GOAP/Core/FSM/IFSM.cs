using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IFSM<TLabel>
    {
        TLabel CurrentState { get; }
        TLabel PreviousState { get; }
        void AddState(TLabel label,IFSMState<TLabel> state);
        void ChangeState(TLabel newState);
        void FrameFun();
    }

    public interface IFSMState<TLabel>
    {
        TLabel Label { get; }
        void Enter();
        void Excute();
        void Exit();
    }

    public class FSM<TLabel> : IFSM<TLabel>
    {
        public TLabel CurrentState { get { return _currentState.Label; } }

        public TLabel PreviousState { get { return _previousState.Label; } }

        private IFSMState<TLabel> _currentState;
        private IFSMState<TLabel> _previousState;
        private Dictionary<TLabel, IFSMState<TLabel>> _stateDic;

        public FSM()
        {
            _stateDic = new Dictionary<TLabel, IFSMState<TLabel>>();
        }

        public void AddState(TLabel label,IFSMState<TLabel> state)
        {
            _stateDic.Add(label, state);
        }

        public void ChangeState(TLabel newState)
        {
            if(!_stateDic.ContainsKey(newState))
            {
                DebugMsg.LogError("状态机内不包含此状态对象：" + newState);
                return;
            }

            _previousState = _currentState;
            _currentState = _stateDic[newState];

            _previousState?.Exit();
            _currentState?.Enter();
        }

        public void FrameFun()
        {
            _currentState?.Excute();
        }
    }
}
