using UnityEngine;
using GOAP;

namespace GOAPTest
{
    public class CustomMap : MapBase<ActionEnum, GoalEnum>
    {
        public CustomMap(IAgent<ActionEnum, GoalEnum> agent) : base(agent) { }

        protected override void InitActionMap()
        {
            AddAction<IdleHandler , IdleAction>();
            AddAction<AttackIdleHandler , AttackIdleAction>();
            AddAction<AttackHandler , AttackAction>();
            AddAction<AlertHandler , AlertAction>();
            AddAction<InjureHandler , InjureAction>();
            AddAction<MoveHandler , MoveAction>();
        }

        protected override void InitGoalMap()
        {
            AddGoal<AlertGoal>();
            AddGoal<AttackGoal>();
            AddGoal<AttackIdleGoal>();
            AddGoal<InjureGoal>();
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectInScene.Instance.Enemy);
            SetGameData(DataName.ENEMY_TRANS, ObjectInScene.Instance.Player);
        }
    }
}
