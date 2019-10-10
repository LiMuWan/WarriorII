using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class IdleSwordView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE_SWORD; } }

        public IdleSwordView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _AniMgr.Play(AIPeasantAniName.idleSword);
        }
    }
}
