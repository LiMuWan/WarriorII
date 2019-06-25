using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public abstract class GameStateSystemBase : ReactiveSystem<GameEntity>  
    {
        protected Contexts contexts;
        public GameStateSystemBase(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }
    
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameState);
        }

        protected override bool Filter(GameEntity entity)
        {
           return entity.hasGameGameState && FilterCondition(entity);
        }

        protected abstract bool FilterCondition(GameEntity entity);
    }

    /// <summary>
    /// ��Ϸ��ʼ��Ӧ�¼�
    /// </summary>
    public class GameStartSystem : GameStateSystemBase
    {
        public GameStartSystem(Contexts contexts):base(contexts)
        { }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.START;
        }

        protected override void Execute(List<GameEntity> entities) 
        {
            contexts.service.gameServiceLoadService.LoadService.LoadPlayer();
            contexts.game.ReplaceGameCameraState(CameraAniName.START_GAME_ANI);
        }
    }

    public class GamePauseSystem : GameStateSystemBase
    {
        public GamePauseSystem(Contexts contexts):base(contexts)
        { }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.PAUSE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }

    public class GameEndSystem : GameStateSystemBase
    {
        public GameEndSystem(Contexts contexts):base(contexts)
        { }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.END;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
