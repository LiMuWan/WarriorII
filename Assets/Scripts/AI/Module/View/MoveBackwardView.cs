using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class MoveBackwardView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MoveBackward; } }
    }
}
