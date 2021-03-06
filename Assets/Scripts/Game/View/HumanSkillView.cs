using Entitas;
using Entitas.Unity;
using Manager;
using System.Collections.Generic;
using UnityEngine;
using Game.Effect;
using Game.Service;
using Module.Timer;

namespace Game.View
{
    public class HumanSkillView:ViewBase,IGamePlayHumanSkillListener     
    {
        private float effectDuration;
        private TimerService timerService;
        private ITimer timer;
        private string timerId;
        private Contexts contexts;

        List<HumanSkillItem> itemList;
        SkillCodeMudule codeMudule;
        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            this.contexts = contexts;
            gameEntity.AddGamePlayHumanSkillListener(this);
            itemList = new List<HumanSkillItem>();
            codeMudule = new SkillCodeMudule();
            SetActive(false);
            effectDuration = 0.5f;
            HideImage();
            timerId = "HumanSkillView";
        }

        private void InitTimerService()
        {
            if (timerService == null)
            {
                timerService = contexts.service.gameServiceTimerService.TimerService;
            }
        }

        private void HideImage()
        {
            gameObject.HideAllImageEffect(effectDuration);
        }

        private void StartTimer()
        {
            InitTimerService();

            timer = timerService.CreateOrRestartTimer(timerId, 1, false);
            timer.AddCompleteListener(HideImage);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// 生成子项，传入参数为“xo”的技能编码字符串
        /// </summary>
        /// <param name="codeString"></param>
        public void ShowItem(string codeString)
        {
            SpawItem(codeString);
            ShowCode(codeString);
        }

        private void SpawItem(string skillCode)
        {
            if (itemList.Count < skillCode.Length)
            { 
                foreach (char c in skillCode)
                {
                    SpawNewItem();
                }
            }
        }

        private void SpawNewItem()
        {
            var go = LoadManager.Single.LoadAndInstantiate(Const.Path.HUMAN_SKILL_ITEM_UI_PATH, transform);
            var item = go.AddComponent<HumanSkillItem>();
            item.Init();
            itemList.Add(item);
        }

        private void ShowCode(string codeString)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if(i < codeString.Length)
                {
                    itemList[i].ChangeSprite(codeString[i]);
                }
                else
                {
                    itemList[i].SetActive(false);
                }
            }
        }

        public void OnGamePlayHumanSkill(GameEntity entity, int SkillCode)
        {
            SetActive(true);
            gameObject.ShowAllImageEffect(effectDuration);
            string skillCode = codeMudule.GetCodeString(SkillCode);
            ShowItem(skillCode);
            StartTimer();
        }
    }
}
