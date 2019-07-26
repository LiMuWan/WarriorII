using Entitas;
using System.Collections.Generic;

/// <summary>
/// 人物行为状态响应系统
/// </summary>
public abstract class GameHumanBehaviourStateSystemBase:ReactiveSystem<GameEntity> 
{
    protected Contexts contexts;

    public   GameHumanBehaviourStateSystemBase(Contexts contexts): base(contexts.game)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)     
    {
        return context.CreateCollector(GameMatcher.GameHumanBehaviourState);
    }

    protected  override bool Filter(GameEntity entity)    
    {
        return entity.hasGameHumanBehaviourState && FilterCondition(entity);
    }

    protected abstract bool FilterCondition(GameEntity entity);
}

public abstract class GameHumanBehaviourEnterStateSystem : GameHumanBehaviourStateSystemBase
{
    protected Contexts contexts;

    public GameHumanBehaviourEnterStateSystem(Contexts contexts) : base(contexts)
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

    protected override bool FilterCondition(GameEntity entity)
    {
        return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.ENTER; 
    }
}

public abstract class GameHumanBehaviourUpdateStateSystem : GameHumanBehaviourStateSystemBase
{
    protected Contexts contexts;

    public GameHumanBehaviourUpdateStateSystem(Contexts contexts) : base(contexts)
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

    protected override bool FilterCondition(GameEntity entity)
    {
        return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.UPDATE;
    }
}

public abstract class GameHumanBehaviourExitStateSystem : GameHumanBehaviourStateSystemBase
{
    protected Contexts contexts;

    public GameHumanBehaviourExitStateSystem(Contexts contexts) : base(contexts)
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

    protected override bool FilterCondition(GameEntity entity)
    {
        return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.EXIT;
    }
}

