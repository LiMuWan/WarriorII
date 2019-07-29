using Entitas;
namespace Game
{
    public class GameInitGameSystem:IInitializeSystem     
    {
        protected Contexts contexts;

        public   GameInitGameSystem(Contexts contexts)         
        {
            this.contexts = contexts;
        }

        public  void Initialize()         
        {
            contexts.service.gameServiceLoadService.LoadService.LoadPlayer();
        }
    }
}
