using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class CurrentActMgr : ActionManagerBase<ActionEnum, GoalEnum>
    {
        public CurrentActMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override ActionEnum GetDefaultActionLable()
        {
            return ActionEnum.IDLE;
        }

        protected override void InitActionHandler()
        {
            AddHandler(ActionEnum.IDLE);
            AddHandler(ActionEnum.MOVE);
            AddHandler(ActionEnum.ATTACK);
            AddHandler(ActionEnum.ATTACK_IDLE);
            AddHandler(ActionEnum.INJURE);
        }
    }
}
