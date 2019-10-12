﻿using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class MoveView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }

        public override string AniName { get { return AIPeasantAniName.runSword.ToString(); } }

        public MoveView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
