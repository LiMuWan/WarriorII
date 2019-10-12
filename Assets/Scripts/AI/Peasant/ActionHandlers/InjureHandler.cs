﻿using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class InjureHandler : HandlerBase<IModel>
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入受伤状态");

            int injureValue = GetGameDataValue<int>(GameDataKeyEnum.INJURE_VALUE);
            EnemyData data = GetGameData<EnemyData>(GameDataKeyEnum.CONFIG);

            data.Life = data.Life - injureValue;

            if(data.Life < 0)
            {
                SetAgentState(StateKeyEnum.IS_DEAD, true);
            }

            //todo:动画执行完毕，执行OnComplete
            OnComplete();
        }
    }
}
