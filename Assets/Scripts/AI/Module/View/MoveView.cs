﻿using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class MoveView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }
    }
}
