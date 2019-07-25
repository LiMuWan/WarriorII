using Const;
using Entitas;
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
            string key = PlayerAniIndex.IDLE.ToString().ToLower();
            if(key.Contains(name))
            {

            }
        }

        private void Update(string name)
        {

        }

        private void Exit(string name)
        {

        }
    }
}
