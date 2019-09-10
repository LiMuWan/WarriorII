using UnityEngine;

namespace GOAP
{
    public interface IGoal<TGoal>
    {
        TGoal Lable { get;}

        float GetPriority();

        IState GetEffects();

        bool IsGoalComplete();

        void AddGoalActivateListener(System.Action<IGoal<TGoal>> onActivate);

        void AddGoalInactivateListener(System.Action<IGoal<TGoal>> onInactivate);

        void UpdateData();
    }
}
