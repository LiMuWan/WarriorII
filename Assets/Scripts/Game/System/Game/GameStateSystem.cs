using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class GameStateSystem : ReactiveSystem<GameEntity>  
    {

        public GameStateSystem(Contexts context):base(context.game)
        {

        }
    
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameState);
        }

        protected override bool Filter(GameEntity entity)
        {
           return entity.hasGameGameState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();  
        }
    }
}
