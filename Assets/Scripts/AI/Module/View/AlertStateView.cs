using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AlertStateView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ALERT_STATE; } }

        public AlertStateView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
