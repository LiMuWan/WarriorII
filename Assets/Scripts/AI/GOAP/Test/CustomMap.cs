using UnityEngine;
using GOAP;

namespace GOAPTest
{
    public class CustomMap : MapBase<ActionEnum, GoalEnum>
    {
        public CustomMap() : base() { }

        protected override void InitActionMap()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectInScene.Instance.Enemy);
            SetGameData(DataName.ENEMY_TRANS, ObjectInScene.Instance.Player);
        }

        protected override void InitGoalMap()
        {
            throw new System.NotImplementedException();
        }
    }
}
