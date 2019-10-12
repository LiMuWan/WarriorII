using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class MoveView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }

        public MoveView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _AniMgr.Play(AIPeasantAniName.runSword);
        }
    }
}
