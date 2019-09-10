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
}
