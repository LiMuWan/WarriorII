using Entitas;
using UnityEngine;

namespace Game
{
    public class InitViewSystem : IInitializeSystem
    {
        private Contexts contexts;
        public InitViewSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            var views = contexts.game.gameFindObjectService.FindObjectService.FindAllView();
            foreach (IView view in views)
            {
                view.Init();
            }
        }
    }
}
