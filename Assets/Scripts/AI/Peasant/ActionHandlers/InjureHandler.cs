using UnityEngine;
using BlueGOAP;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class InjureHandler<TModel> : HandlerBase<TModel> where TModel : class , IModel
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {

        }

        public override void Enter()
        {
            
            DebugMsg.Log("进入受伤状态");

            int injureValue = GetGameDataValue<int>(GameDataKeyEnum.INJURE_VALUE);
            EnemyData data = GetGameData<EnemyData>(GameDataKeyEnum.CONFIG);

            data.Life = data.Life - injureValue;

            if(data.Life < 0)
            {
                SetAgentState(StateKeyEnum.IS_DEAD, true);
            }
            else
            {
                base.Enter();
            }
        }
    }

    public class InjureUpHandler : InjureHandler<InjureUpModel>
    {
        public InjureUpHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }

    public class InjureDownHandler : InjureHandler<InjureDownModel>
    {
        public InjureDownHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }

    public class InjureLeftHandler : InjureHandler<InjureLeftModel>
    {
        public InjureLeftHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }

    public class InjureRightHandler : InjureHandler<InjureRightModel>
    {
        public InjureRightHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }
    }
}
