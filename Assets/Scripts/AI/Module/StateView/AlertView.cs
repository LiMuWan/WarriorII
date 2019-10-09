using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AlertView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ALERT; } }

        public AlertView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
