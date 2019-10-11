using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class DeadHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public DeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            int injureValue = GetGameDataValue<GameDataKeyEnum,int>(GameDataKeyEnum.INJURE_VALUE);

            switch (injureValue)
            {
                case Const.INSTANT_KILL:
                    //todo: 一击必杀效果
                    break;
                default:
                    //todo: 正常死亡逻辑
                    break;
            }

            DebugMsg.Log("进入死亡状态");
        }
    }
}
