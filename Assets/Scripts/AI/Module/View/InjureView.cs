using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class InjureView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE; } }

        public override string AniName { get { return AIPeasantAniName.injuryBack.ToString(); } }

        public InjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
