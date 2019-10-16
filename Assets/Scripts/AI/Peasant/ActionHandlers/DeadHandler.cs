using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;
using Game.AI.Model;

namespace Game.AI
{
    public abstract class DeadHandler : HandlerBase<IModel>
    {
        public DeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            int injureValue = GetGameDataValue<int>(GameDataKeyEnum.INJURE_VALUE);

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

        private void JudgeDead()
        {
            //todo:获取死亡方式的数据
        }
    }

    public class NormalDeadHandler : DeadHandler
    {
        public NormalDeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }
}
