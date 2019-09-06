using UnityEngine;

namespace GOAP
{
    public interface IAgent
    {
        
        IState AgentState { get; }

        void UpdateData();

        void FrameFun();
    }

    public abstract class AgentBase:IAgent
    {
        public IState AgentState { get; private set; }

        public AgentBase()
        {
            DebugBase.Instance = InitDebugBase();
            AgentState = new State();
            AgentState.AddStateChangeListener(UpdateData);
        }

        protected abstract DebugBase InitDebugBase();

        public void UpdateData()
        {

        }

        public void FrameFun()
        {

        }
    }
}
