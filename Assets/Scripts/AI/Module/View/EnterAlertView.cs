using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class EnterAlertView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ENTER_ALERT; } }

        public EnterAlertView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {
            AlertModel model = _iModel as AlertModel;
            model.ShowSwordDuration = _AniMgr.GetAniLength(AIPeasantAniName.showSword);
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log(AIPeasantAniName.showSword.ToString());
            _AniMgr.Play(AIPeasantAniName.showSword);
        }
    }
}
