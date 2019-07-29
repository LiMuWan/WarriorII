using Const;
using Entitas;
using System;
using System.Threading.Tasks;

namespace Game
{
    public class GameHumanAniEventSystem:IInitializeSystem     
    {
        protected Contexts contexts;

        public   GameHumanAniEventSystem(Contexts contexts)         
        {
            this.contexts = contexts;
        }

        public  void Initialize()
        {
            ICustomAniEventManager manager = contexts.game.gamePlayer.PlayerAni.AniEventManager;
            manager.AddEventListener(Enter,Update,Exit);
        }

        private void Enter(string name)
        {
            ReplaceGameHumanBehaviourState(name, BehaviourState.ENTER);
        }

        private void Update(string name)
        {
            ReplaceGameHumanBehaviourState(name, BehaviourState.UPDATE);
        }

        private void Exit(string name)
        {
            ReplaceGameHumanBehaviourState(name, BehaviourState.EXIT);
        }

        private void ReplaceGameHumanBehaviourState(string name, BehaviourState behaviourState)
        {
            foreach (PlayerBehaviourIndex playerBehaviour in Enum.GetValues(typeof(PlayerBehaviourIndex)))
            {
                ReplaceGameHumanBehaviourState(name, playerBehaviour,behaviourState);
            }
        }

        private void ReplaceGameHumanBehaviourState(string name, PlayerBehaviourIndex behaviour,BehaviourState behaviourState)
        {
            string key = behaviour.ToString().ToLower();
            if (name.Contains(key))
            {
                contexts.game.ReplaceGameHumanBehaviourState(behaviour, behaviourState);
            }
        }
    }
}
