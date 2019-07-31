using Entitas;
using System.Collections.Generic;

namespace Game
{
    public class GameSkillManagerSystem:IInitializeSystem,IGameValidHumanSkillListener     
    {
        protected Contexts contexts;
        private Queue<int> codeCache;

        public  GameSkillManagerSystem(Contexts contexts)         
        {
            this.contexts = contexts;
            codeCache = new Queue<int>();
        }

        public  void Initialize()         
        {
           var entity = contexts.game.CreateEntity();
           entity.AddGameValidHumanSkillListener(this);
        }

        public void OnGameValidHumanSkill(GameEntity entity, int SkillCode)
        {
            codeCache.Enqueue(SkillCode);
        }
    }
}
