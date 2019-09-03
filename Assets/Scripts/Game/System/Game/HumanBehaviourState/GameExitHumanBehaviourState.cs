using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameHumanIdleExitStateSystem : GameHumanBehaviourStateExitSystemBase
    {

        public GameHumanIdleExitStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.IDLE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
 
        }
    }

    public class GameHumanWalkExitStateSystem : GameHumanBehaviourStateExitSystemBase
    {

        public GameHumanWalkExitStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.WALK;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }

    public class GameHumanAttackExitStateSystem : GameHumanBehaviourStateExitSystemBase
    {

        public GameHumanAttackExitStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.EXIT;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }
}
