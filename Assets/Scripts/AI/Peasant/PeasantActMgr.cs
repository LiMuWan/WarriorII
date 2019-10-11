using UnityEngine;
using BlueGOAP;
using System;

namespace Game.AI
{
    public class PeasantActMgr : ActionManagerBase<ActionEnum, GoalEnum>
    {
        private Action<ActionEnum> _executeActionState;

        public PeasantActMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override ActionEnum GetDefaultActionLabel()
        {
            return ActionEnum.IDLE;
        }

        protected override void InitActionHandlers()
        {
            AddActionHandler(ActionEnum.IDLE);
            AddActionHandler(ActionEnum.IDLE_SWORD);
            AddActionHandler(ActionEnum.MOVE);
            AddActionHandler(ActionEnum.MoveBackward);
            AddActionHandler(ActionEnum.ATTACK);
            AddActionHandler(ActionEnum.DEAD);
            AddActionHandler(ActionEnum.ENTER_ALERT);
            AddActionHandler(ActionEnum.EXIT_ALERT);
        }

        protected override void InitActionStateHandlers()
        {
            AddActionStateHandler(ActionEnum.ALERT_STATE);
        }

        public void AddExecuteNewStateListener(Action<ActionEnum> executeActionState)
        {
            _executeActionState = executeActionState;
        }

        public override void ExcuteNewState(ActionEnum label)
        {
            base.ExcuteNewState(label);
            if(_executeActionState != null)
               _executeActionState(label);
        }
    }
}
