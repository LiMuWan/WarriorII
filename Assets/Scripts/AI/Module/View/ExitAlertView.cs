using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class ExitAlertView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.EXIT_ALERT; } }

        public ExitAlertView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {
            ExitAlertModel model = _iModel as ExitAlertModel;
            model.AniDuration = _AniMgr.GetAniLength(AIPeasantAniName.hideSword);
        }

        public override void Enter()
        {
            base.Enter();
            _AniMgr.Play(AIPeasantAniName.hideSword);
        }
    }
}
