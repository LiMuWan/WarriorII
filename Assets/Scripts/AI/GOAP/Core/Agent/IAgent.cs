using UnityEngine;

namespace GOAP
{
    public interface IAgent<TAction,TGoal>
        where TAction : struct
        where TGoal : struct
    {
        
        IState AgentState { get; }

        IMap<TAction,TGoal> Map { get; }

        void UpdateData();

        void FrameFun();
    }

    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
         where TAction : struct
         where TGoal : struct
    {
        public IState AgentState { get; private set; }

        public IMap<TAction, TGoal> Map { get; private set; }

        public AgentBase()
        {
            DebugBase.Instance = InitDebugBase();
            AgentState = new State();
            Map = InitMap();
            AgentState.AddStateChangeListener(UpdateData);
        }

        protected abstract DebugBase InitDebugBase();

        protected abstract IMap<TAction, TGoal> InitMap();

        public void UpdateData()
        {

        }

        public void FrameFun()
        {

        }
    }
}
