using Entitas;
using Entitas.Unity;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Game.View
{
    public class HumanSkillView:ViewBase     
    {
        List<GameObject> itemList;
        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            itemList = new List<GameObject>();
        }

        private void SpawItem(string skillCode)
        {
            if (itemList.Count < skillCode.Length)
            {
                GameObject go = null;
                foreach (char c in skillCode)
                {
                    SpawNewItem(go, c);
                }
            }
        }

        private void SpawNewItem(GameObject go,char code)
        {
            go = LoadManager.Single.LoadAndInstantiate(Const.Path.GAME_UI_PATH + code, transform);
            itemList.Add(go);
        }
    }
}
