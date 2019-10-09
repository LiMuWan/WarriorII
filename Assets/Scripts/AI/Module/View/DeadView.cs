﻿using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class DeadView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }
    }
}
