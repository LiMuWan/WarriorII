using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class PlayerAniStateSystem : ReactiveSystem<GameEntity>
    {
        private Contexts contexts;
        public PlayerAniStateSystem(Contexts contexts):base(contexts.game)
        {
            this.contexts = contexts;
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
           return context.CreateCollector(GameMatcher.GamePlayerAniState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGamePlayerAniState;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            
        }

    }
}
