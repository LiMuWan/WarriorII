using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameHumanIdleEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanIdleEnterStateSystem(Contexts contexts) : base(contexts)
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

    public class GameHumanWalkEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanWalkEnterStateSystem(Contexts contexts) : base(contexts)
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

    public class GameHumanAttackEnterStateSystem : GameHumanBehaviourStateEnterSystemBase
    {

        public GameHumanAttackEnterStateSystem(Contexts contexts) : base(contexts)
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
