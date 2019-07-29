using Entitas;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// 人物行为状态响应系统父类
    /// </summary>
    public abstract class GameHumanBehaviourStateSystemBase : ReactiveSystem<GameEntity>
    {
        protected Contexts contexts;

        public GameHumanBehaviourStateSystemBase(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameHumanBehaviourState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameHumanBehaviourState && FilterCondition(entity);
        }

        protected abstract bool FilterCondition(GameEntity entity);
    }

    /// <summary>
    /// 进入人物状态响应系统父类
    /// </summary>
    public abstract class GameHumanBehaviourStateEnterSystemBase : GameHumanBehaviourStateSystemBase
    {

        public GameHumanBehaviourStateEnterSystemBase(Contexts contexts) : base(contexts)
        {
            
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameHumanBehaviourState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameHumanBehaviourState && FilterCondition(entity) && StateCondition(entity);
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.ENTER;
        }

        protected abstract bool StateCondition(GameEntity entity);
    }

    /// <summary>
    /// 正在执行的人物状态响应父类
    /// </summary>
    public abstract class GameHumanBehaviourStateUpdateSystemBase : GameHumanBehaviourStateSystemBase
    {

        public GameHumanBehaviourStateUpdateSystemBase(Contexts contexts) : base(contexts)
        {
       
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameHumanBehaviourState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameHumanBehaviourState && FilterCondition(entity) && StateCondition(entity);
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.UPDATE;
        }

        protected abstract bool StateCondition(GameEntity entity);
    }

    /// <summary>
    /// 退出人物行为状态的响应系统父类
    /// </summary>
    public abstract class GameHumanBehaviourStateExitSystemBase : GameHumanBehaviourStateSystemBase
    {

        public GameHumanBehaviourStateExitSystemBase(Contexts contexts) : base(contexts)
        {
           
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameHumanBehaviourState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameHumanBehaviourState && FilterCondition(entity) && StateCondition(entity);
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.EXIT;
        }

        protected abstract bool StateCondition(GameEntity entity);
    }
}

