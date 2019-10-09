using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class IdleSwordView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE_SWORD; } }
    }
}
