using Entitas;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// 人物技能管理类
    /// </summary>
    public class GameSkillManagerSystem:IInitializeSystem,IGameValidHumanSkillListener     
    {
        protected Contexts contexts;
        private Queue<int> codeCache;

        private int cacheLengthMax;

        public  GameSkillManagerSystem(Contexts contexts)         
        {
            this.contexts = contexts;
            codeCache = new Queue<int>();
            cacheLengthMax = 2;
        }

        public  void Initialize()         
        {
           var entity = contexts.game.CreateEntity();
           entity.AddGameValidHumanSkillListener(this);
        }

        public void OnGameValidHumanSkill(GameEntity entity, int SkillCode)
        {
            AddCode(SkillCode);
        }

        private void AddCode(int SkillCode)
        {
            if (codeCache.Count < cacheLengthMax)
            {
                codeCache.Enqueue(SkillCode);
            }
        }

        private void PlaySkill()
        {
            if(contexts.game.gamePlayer.PlayerBehaviour.IsAttack)
            {
                //play 第一个code
            }
        }
    }
}
