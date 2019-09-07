using UnityEngine;

namespace GOAP
{
    public interface IAction<TAction>
    {
        TAction Label { get; }
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

    public abstract class ActionBase<TAction,TGoal>:IAction<TAction>
    {
        public abstract TAction Label { get; }

        public int Cost { get; }

        public int Priority { get; }

        public bool CanInterruptiblePlan { get; }

        public IState Preconditions { get; private set; }

        public IState Effects { get; private set; }

        private IAgent<TAction, TGoal> _agent;

        public ActionBase(IAgent<TAction, TGoal> agent)
        {
            Preconditions = InitPreconditions();
            Effects = InitEffects();
        }

        protected abstract IState InitPreconditions();
        protected abstract IState InitEffects();

        public bool VerifyPreconditons()
        {
            return _agent.AgentState.ContainState(Preconditions);
        }
    }

    
}
