using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class ExitAlertView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.EXIT_ALERT; } }

        public ExitAlertView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {
            AlertModel model = _iModel as AlertModel;
            model.HideSwordDuration = _AniMgr.GetAniLength(AIPeasantAniName.hideSword);
        }

        public override void Enter()
        {
            base.Enter();
            _AniMgr.Play(AIPeasantAniName.hideSword);
        }
    }
}
