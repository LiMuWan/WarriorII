using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    public interface IGoalManager<TGoal>
    {
        IGoal<TGoal> Current { get; }

        void AddGoal(TGoal label);

        void RemoveGoal(TGoal label);

        IGoal<TGoal> GetGoal(TGoal label);

        IGoal<TGoal> FindGoal();

        void UpdateData(); 
    }

    public abstract class GoalManagerBase<TAction,TGoal> : IGoalManager<TGoal>
    {
        public IGoal<TGoal> Current { get; private set; }

        private Dictionary<TGoal, IGoal<TGoal>> _goalsDic;
        private List<IGoal<TGoal>> _activeGoals;
 
        private IAgent<TAction, TGoal> _agent;

        public GoalManagerBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _goalsDic = new Dictionary<TGoal, IGoal<TGoal>>();
            _activeGoals = new List<IGoal<TGoal>>();
            InitGoals();
            
        }

        protected abstract void InitGoals();

        public void AddGoal(TGoal label)
        {
            var goal = _agent.Map.GetGoal(label);
            if(goal != null)
            {
                _goalsDic.Add(label, goal);

                goal.AddGoalActivateListener((currentGoal) =>
                {
                    if(!_activeGoals.Contains(currentGoal))
                    {
                        _activeGoals.Add(currentGoal);
                    }
                });

                goal.AddGoalInactivateListener((currentGoal) =>
                {
                    if(_activeGoals.Contains(currentGoal))
                    {
                        _activeGoals.Remove(currentGoal);
                    }
                });
            }
        }

        public void RemoveGoal(TGoal label)
        {
            _goalsDic.Remove(label);
        }

        public IGoal<TGoal> GetGoal(TGoal label)
        {
            if(_goalsDic.ContainsKey(label))
            {
                return _goalsDic[label];
            }

            DebugMsg.LogError("当前代理未初始化此目标，标签为 ：" + label);
            return null;
        }

        public IGoal<TGoal> FindGoal()
        {
            _activeGoals = _activeGoals.OrderByDescending(u => u.GetPriority()).ToList();
            if(_activeGoals.Count > 0)
            {
                return _activeGoals[0];
            }
            else
            {
                return null;
            }
        }

        public void UpdateData()
        {
            UpdateGoals();
            UpdateCurrentGoal();
        }

        private void UpdateGoals()
        {
            foreach (var goal in _goalsDic)
            {
                goal.Value.UpdateData();
            }
        }

        private void UpdateCurrentGoal()
        {
            Current = FindGoal();

            if (Current == null)
                DebugMsg.LogError("当前目标为空");
        }
    }
}
