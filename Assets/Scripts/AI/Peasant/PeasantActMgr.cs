using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class PeasantActMgr : ActionManagerBase<ActionEnum, GoalEnum>
    {
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
            AddActionHandler(ActionEnum.ATTACK);
            AddActionHandler(ActionEnum.MOVE);
        }

        protected override void InitActionStateHandlers()
        {
            AddActionStateHandler(ActionEnum.ALERT);
        }
    }
}
