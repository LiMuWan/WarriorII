using UnityEngine;

namespace GOAP
{
    public interface IFSM<TLabel>
    {
       TLabel CurrentState { get; }
        TLabel BeforeTheState { get; }
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
}
