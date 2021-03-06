using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameHumanIdleEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanIdleEnterStateSystem(Contexts contexts) : base(contexts)
        {
            
        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.IDLE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Idle();
            contexts.game.gamePlayer.PlayerAudio.Idle();
        }
    }

    public class GameHumanWalkEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanWalkEnterStateSystem(Contexts contexts) : base(contexts)
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

    public class GameHumanAttackEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanAttackEnterStateSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool StateCondition(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.PlayerBehaviourIndex == Const.PlayerBehaviourIndex.ATTACK;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            
        }
    }
}
