using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class DeadView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }

        public override string AniName { get { return AIPeasantAniName.death01.ToString(); } }

        public DeadView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
