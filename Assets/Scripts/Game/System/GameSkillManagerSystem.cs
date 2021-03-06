using Entitas;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// 人物技能管理类
    /// </summary>
    public class GameSkillManagerSystem : IInitializeSystem, IGameValidHumanSkillListener, IGameEndHumanSkillListener
    {
        protected Contexts contexts;
        private Queue<int> codeCache;
        //缓存指令最大数量
        private int cacheLengthMax;
        private int currentPlayingCode;

        public GameSkillManagerSystem(Contexts contexts)
        {
            this.contexts = contexts;
            codeCache = new Queue<int>();
            cacheLengthMax = 2;
        }

        public void Initialize()
        {
            var entity = contexts.game.CreateEntity();
            entity.AddGameValidHumanSkillListener(this);
            entity.AddGameEndHumanSkillListener(this);
        }

        public void OnGameEndHumanSkill(GameEntity entity, int SkillCode)
        {
            if (currentPlayingCode == SkillCode)
            {
                bool isPlayFailed = !PlaySkill();
                if (isPlayFailed)
                {
                    contexts.game.ReplaceGamePlayHumanSkill(0);
                }
            }
        }

        public void OnGameValidHumanSkill(GameEntity entity, int SkillCode)
        {
            AddCode(SkillCode);
            if (!contexts.game.gamePlayer.PlayerBehaviour.IsAttack)
            { 
                PlaySkill();
            }
        }

        private void AddCode(int SkillCode)
        {
            if (codeCache.Count < cacheLengthMax)
            {
                codeCache.Enqueue(SkillCode);
            }
        }

        private bool PlaySkill()
        {
            if (codeCache.Count <= 0)
                return false;
            int code = codeCache.Dequeue();
            currentPlayingCode = code;
            contexts.game.ReplaceGamePlayHumanSkill(currentPlayingCode);
            return true;
        }
    }
}
