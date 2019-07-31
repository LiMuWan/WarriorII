using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.View
{
    public class TrailComboManager:ViewBase,IGameStartHumanSkillListener,IGameEndHumanSkillListener     
    {
        private string prefixName = "trail_";
        private Dictionary<int, Transform> trailsDic;

        public override void Init(Contexts contexts, IEntity entity)
        {
            base.Init(contexts, entity);
            GameEntity gameEntity = entity as GameEntity;
            gameEntity.AddGameStartHumanSkillListener(this);
            gameEntity.AddGameEndHumanSkillListener(this);
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

        private void ShowTrails(int code)
        {
            SetActive(trailsDic[code], true);
        }

        private void HideTrails(int code)
        {
            SetActive(trailsDic[code], false);
        }

        private void SetActive(Transform trans,bool isActive)
        {
            trans.gameObject.SetActive(isActive);
        }

        public void OnGameStartHumanSkill(GameEntity entity, int SkillCode)
        {
            ShowTrails(SkillCode);
        }

        public void OnGameEndHumanSkill(GameEntity entity, int SkillCode)
        {
            HideTrails(SkillCode);
        }
    }
}
