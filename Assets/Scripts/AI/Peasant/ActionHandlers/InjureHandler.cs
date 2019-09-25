﻿using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class InjureHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入受伤状态");

            int injureValue = (int)GetGameData(GameDataKeyEnum.INJURE_VALUE);
            int life = (int)GetGameData(GameDataKeyEnum.LIFE);

            life = life - injureValue;

            if(life < 0)
            {
                SetAgentState(StateKeyEnum.DEAD, true);
            }

            //todo:动画执行完毕，执行OnComplete
            OnComplete();
        }
    }
}
