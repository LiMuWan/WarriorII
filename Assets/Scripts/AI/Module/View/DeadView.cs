using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class DeadView : ViewBase<ActionEnum>
    {
        public DeadView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

    public abstract class DeadNormalView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }

        public override string AniName { get; }

        public DeadNormalView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

}
