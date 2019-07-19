using Entitas;
using Entitas.Unity;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Game.View
{
    public class HumanSkillView:ViewBase     
    {
        List<HumanSkillItem> itemList;
        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            itemList = new List<HumanSkillItem>();
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
            itemList.Add(item);
        }

        private void ShowCode(string codeString)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if(i <= codeString.Length)
                {
                    itemList[i].ChangeSprite(codeString[i]);
                }
                else
                {
                    itemList[i].SetActive(false);
                }
            }
        }
    }
}
