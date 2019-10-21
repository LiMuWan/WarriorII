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

        public override bool CanPerformAction()
        {
            bool result = base.CanPerformAction() && JudgeDead();
            ((DeadAction)Action).ChangePriority(result);
            return result;
        }

        protected abstract bool JudgeDead();
    }

    /// <summary>
    /// 普通死亡方式
    /// </summary>
    public class NormalDeadHandler : DeadHandler
    {
        public NormalDeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        protected override bool JudgeDead()
        {
            return true;
        }
    }

    /// <summary>
    /// 一击必杀死亡方式
    /// </summary>
    public class InstantSkillDeadHandler : DeadHandler
    {
        public InstantSkillDeadHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        protected override bool JudgeDead()
        {
            int injureValue = GetGameDataValue<int>(GameDataKeyEnum.INJURE_VALUE);
            var dataDic = GetGameData<Dictionary<ActionEnum, bool>>(GameDataKeyEnum.INJURE_COLLECT_DATA);
            bool result = dataDic.ContainsKey(Label) && dataDic[Label] && injureValue == Const.INSTANT_KILL;
            dataDic[Label] = false;
            return result;
        }
    }
}
