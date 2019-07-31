using Entitas;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// ���＼�ܹ�����
    /// </summary>
    public class GameSkillManagerSystem:IInitializeSystem,IGameValidHumanSkillListener,IGameEndHumanSkillListener     
    {
        protected Contexts contexts;
        private Queue<int> codeCache;
        //����ָ���������
        private int cacheLengthMax;
        private int currentPlayingCode;

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
           entity.AddGameEndHumanSkillListener(this);
        }

        public void OnGameEndHumanSkill(GameEntity entity, int SkillCode)
        {
            if(currentPlayingCode == SkillCode)
            {
                PlaySkill();
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

        private void PlaySkill()
        {
            if (codeCache.Count < 0)
                return;
            int code = codeCache.Dequeue();
            currentPlayingCode = code;
            //����ִ���ź�
        }
    }
}
