using UnityEngine;

namespace GOAP
{
    public interface IAgent<TAction,TGoal>
    {
        IState AgentState { get; }

        IMap<TAction,TGoal> Map { get; }

        IActionManager<TAction> ActionManager { get; }

        IGoalManager<TGoal> GoalManager { get; }

        IPerform Perform { get; }

        void UpdateData();

        void FrameFun();
    }

    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
         where TAction : struct
         where TGoal : struct
    {
        public IState AgentState { get; private set; }

        public IMap<TAction, TGoal> Map { get; private set; }

        public IActionManager<TAction> ActionManager { get; private set; }

        public IGoalManager<TGoal> GoalManager { get; private set; }

        public IPerform Perform { get; private set; }

        private ITriggerManager _triggerManager;

        public AgentBase()
        {
            DebugBase.Instance = InitDebugBase();
            AgentState = InitState();
            Map = InitMap();
            ActionManager = InitActionManager();
            GoalManager = InitGoalManager();
            AgentState.AddStateChangeListener(UpdateData);
            Perform = new Performer<TAction,TGoal>(this);
            _triggerManager = InitTriggerManager();

            JudgeEception(Map, "Map");
            JudgeEception(ActionManager, "ActionManager");
            JudgeEception(GoalManager, "GoalManager");
            JudgeEception(_triggerManager, "_triggerManager");
        }

        protected abstract DebugBase InitDebugBase();

        protected abstract IMap<TAction, TGoal> InitMap();

        protected abstract IActionManager<TAction> InitActionManager();

        protected abstract IGoalManager<TGoal> InitGoalManager();

        protected abstract ITriggerManager InitTriggerManager();

        protected abstract IState InitState();

        private void JudgeEception(object obj,string name)
        {
            if (obj == null)
                DebugMsg.LogError("代理中" + name + "兑现为空，请在代理子类中初始化该对象");
        }

        public void UpdateData()
        {
            if (ActionManager != null)
                ActionManager.UpdateData();
            if (GoalManager != null)
                GoalManager.UpdateData();

            Perform.UpdateData();
        }

        public void FrameFun()
        {
            if (_triggerManager != null)
                _triggerManager.FrameFun();

            if (ActionManager != null)
                ActionManager.FrameFun();
        }
    }
}
