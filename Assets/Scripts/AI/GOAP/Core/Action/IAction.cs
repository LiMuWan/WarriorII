using UnityEngine;

namespace GOAP
{
    public interface IAction<TAction>
    {
        TAction Lable { get; }
        int Cost { get; }
        int Priority { get; }
        bool CanInterruptiblePlan { get; }
        IState Preconditions { get; }
        IState Effects { get; }
        /// <summary>
        /// 是否满足先决条件
        /// </summary>
        bool VerifyPreconditons();
    }

    public abstract class ActionBase<TAction>:IAction<TAction>
    {
        public abstract TAction Lable { get; }

        public int Cost { get; }

        public int Priority { get; }

        public bool CanInterruptiblePlan { get; }

        public IState Preconditions { get; private set; }

        public IState Effects { get; private set; }

        private IAgent agent;

        public ActionBase(IAgent agent)
        {
            Preconditions = 
        }

        protected abstract IState InitPreconditions();
        protected abstract IState InitEffects();

        public bool VerifyPreconditons()
        {
            return agent.AgentState.ContainState(Preconditions);
        }
    }

    
}
