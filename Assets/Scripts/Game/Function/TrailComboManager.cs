using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.View
{
    public class TrailComboManager:ViewBase,IGameValidHumanSkillListener     
    {
        private string prefixName = "trail_";
        private Dictionary<int, Transform> trailsDic;

        public override void Init(Contexts contexts, IEntity entity)
        {
            base.Init(contexts, entity);
            GameEntity gameEntity = entity as GameEntity;
            gameEntity.AddGameValidHumanSkillListener(this);
            trailsDic = new Dictionary<int, Transform>();
            InitTrailsDic();
            HideAllTrails();
        }

        private void InitTrailsDic()
        {
            foreach (Transform tran in transform)
            {
                trailsDic[GetSkillCode(tran.name)] = tran;
            }
        }

        private int GetSkillCode(string codeName)
        {
            SkillCodeMudule skillCode = new SkillCodeMudule();
            return skillCode.GetSkillCode(codeName,prefixName,"");
        }

        private void HideAllTrails()
        {
            foreach (KeyValuePair<int,Transform> pair in trailsDic)
            {
                SetActive(pair.Value, false);
            }
        }

        public void ShowTrails(int code)
        {
            SetActive(trailsDic[code], true);
        }

        private void SetActive(Transform trans,bool isActive)
        {
            trans.gameObject.SetActive(isActive);
        }

        public void OnGameValidHumanSkill(GameEntity entity, int SkillCode)
        {
            ShowTrails(SkillCode);
        }
    }
}
