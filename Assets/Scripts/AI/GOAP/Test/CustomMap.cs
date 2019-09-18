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
            throw new System.NotImplementedException();
        }

        protected override void InitGoalMap()
        {
            throw new System.NotImplementedException();
        }
    }
}
