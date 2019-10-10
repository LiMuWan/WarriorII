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
            
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
