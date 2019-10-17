using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;
using Game.AI.Model;
using System.Collections.Generic;

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

        private bool JudgeDead()
        {
            var dataDic = GetGameData<Dictionary<ActionEnum, bool>>(GameDataKeyEnum.INJURE_COLLECT_DATA);
            return dataDic[Label];
        }
    }

    public class NormalDeadHandler : DeadHandler
    {
        public NormalDeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }

    public class InstantSkillDeadHandler : DeadHandler
    {
        public InstantSkillDeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }
}
