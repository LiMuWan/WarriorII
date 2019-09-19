using UnityEngine;
using GOAP;

namespace GOAPTest
{
    public class CustomMap : MapBase<ActionEnum, GoalEnum>
    {
        public CustomMap(IAgent<ActionEnum, GoalEnum> agent) : base(agent) { }

        protected override void InitActionMap()
        {
            AddAction(new IdleHandler(_agent, new IdleAction(_agent)));
            AddAction(new AttackIdleHandler(_agent, new AttackIdleAction(_agent)));
            AddAction(new AttackHandler(_agent, new AttackAction(_agent)));
            AddAction(new AlertHandler(_agent, new AlertAction(_agent)));
            AddAction(new InjureHandler(_agent, new InjureAction(_agent)));
            AddAction(new MoveHandler(_agent, new MoveAction(_agent)));
        }

        protected override void InitGoalMap()
        {
            AddGoal(new AlertGoal(_agent));
            AddGoal(new AttackGoal(_agent));
            AddGoal(new AttackIdleGoal(_agent));
            AddGoal(new InjureGoal(_agent));
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectInScene.Instance.Enemy);
            SetGameData(DataName.ENEMY_TRANS, ObjectInScene.Instance.Player);
        }
    }
}
