using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IFSM<TLabel>
    {
        TLabel CurrentState { get; }
        TLabel PreviousState { get; }
        void AddState(TLabel label,IFrameState<TLabel> state);
        void ChangeState(TLabel newState);
        void FrameFun();
    }

    public interface IFrameState<TLabel>
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

        private IFrameState<TLabel> _currentState;
        private IFrameState<TLabel> _previousState;
        private Dictionary<TLabel, IFrameState<TLabel>> _stateDic;

        public FSM()
        {
            _stateDic = new Dictionary<TLabel, IFrameState<TLabel>>();
        }

        public void AddState(TLabel label,IFrameState<TLabel> state)
        {
            _stateDic.Add(label, state);
        }

        public void ChangeState(TLabel newState)
        {
          
        }

        public void FrameFun()
        {
            _currentState?.Excute();
        }
    }
}
