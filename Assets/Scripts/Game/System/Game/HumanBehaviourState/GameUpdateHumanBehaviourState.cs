using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameHumanIdleUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanIdleUpdateStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.UPDATE;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }

    public class GameHumanWalkUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanWalkUpdateStateSystem(Contexts contexts) : base(contexts)
        {
            
        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.WALK ||
                entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.RUN;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Move();
            contexts.game.gamePlayer.PlayerAudio.Move();
        }
    }

    public class GameHumanAttackUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanAttackUpdateStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.UPDATE;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }
}
