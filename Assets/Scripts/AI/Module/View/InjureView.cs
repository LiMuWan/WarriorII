using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class InjureView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE; } }

        public InjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
