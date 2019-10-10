using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class IdleView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE; } }

        public IdleView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _AniMgr.Play(AIPeasantAniName.idle);
        }
    }
}
