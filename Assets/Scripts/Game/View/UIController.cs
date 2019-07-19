using Game;
using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.View
{
    public class UIController : MonoBehaviour
    {
        private HashSet<string> viewPath;

        public void Init()
        {
            InitPath();
            LoadView();

            transform.Find("HumanSkill").GetComponent<HumanSkillView>().ShowItem("XO");
        }

        //添加UI部分加载路径
        private void InitPath()
        {
            viewPath = new HashSet<string>();
            viewPath.Add(Const.Path.HUMAN_SKILL_UI_PATH);
        }

        private void LoadView()
        {
            GameObject temp = null;
            foreach (string path in viewPath)
            {
                temp = LoadManager.Single.LoadAndInstantiate(path, transform);
                temp.GetComponent<ViewBase>()?.Init(Contexts.sharedInstance, Contexts.sharedInstance.game.CreateEntity());
            }
        }
    }
}
