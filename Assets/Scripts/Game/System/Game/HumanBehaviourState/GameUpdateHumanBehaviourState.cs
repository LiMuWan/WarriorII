using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameHumanIdleUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanIdleUpdateStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.IDLE;
        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.ENTER;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }

    public class GameHumanWalkUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanWalkUpdateStateSystem(Contexts contexts) : base(contexts)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Move();
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.IDLE;
        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.ENTER;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }

    public class GameHumanAttackUpdateStateSystem : GameHumanBehaviourStateUpdateSystemBase
    {

        public GameHumanAttackUpdateStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.IDLE;
        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.BehaviourState == Const.BehaviourState.ENTER;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }
}
