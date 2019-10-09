using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AttackView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ATTACK; } }

        public AttackView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
