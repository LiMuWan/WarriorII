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
        /// �Ƿ������Ⱦ�����
        /// </summary>
        bool VerifyPreconditons();
    }

    public abstract class ActionBase<TAction>:IAction<TAction>
    {
        public abstract TAction Label { get; }

        public int Cost { get; }

        public int Priority { get; }

        public bool CanInterruptiblePlan { get; }

        public IState Preconditions { get; private set; }

        public IState Effects { get; private set; }

        private IAgent _agent;

        public ActionBase(IAgent agent)
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
