using Game;
using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Const;

namespace Game.View
{
    public class UIController : MonoBehaviour
    {
        private string nameSpace = "Game.View.";
        private string posfix = "View";
        public void Init()
        {
            LoadView();

            transform.Find("HumanSkill(Clone)").GetComponent<HumanSkillView>().ShowItem("OOXX");
            transform.Find("HumanSkill(Clone)").GetComponent<HumanSkillView>().ShowItem("XO");
        }

        private void LoadView()
        {
            GameObject temp = null;
            Component tempComponent = null;
            foreach (GameUIName uiName in Enum.GetValues(typeof(GameUIName)))
            {
                temp = LoadManager.Single.LoadAndInstantiate(Const.Path.GAME_UI_PATH + uiName, transform);
                tempComponent = temp.AddComponent(Type.GetType(nameSpace + uiName + posfix));
                if (tempComponent is Interface.IView)
                {
                    (tempComponent as Interface.IView).Init(Contexts.sharedInstance, Contexts.sharedInstance.game.CreateEntity());
                }
            }
        }
    }
}
