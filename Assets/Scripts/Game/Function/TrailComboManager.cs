using System.Collections.Generic;
using Entitas;
using Game.Effect;
using UnityEngine;

namespace Game.View
{
    public class TrailComboManager:ViewBase,IGameStartHumanSkillListener,IGameEndHumanSkillListener     
    {
        private string prefixName = "trail_";
        private Dictionary<int, TrailsEffect> trailsDic;

        public override void Init(Contexts contexts, IEntity entity)
        {
            base.Init(contexts, entity);
            GameEntity gameEntity = entity as GameEntity;
            gameEntity.AddGameStartHumanSkillListener(this);
            gameEntity.AddGameEndHumanSkillListener(this);
            trailsDic = new Dictionary<int, TrailsEffect>();
            InitTrailsDic();
            HideAllTrails();
        }

        private void InitTrailsDic()
        {
            foreach (Transform tran in transform)
            {
                trailsDic[GetSkillCode(tran.name)] = tran.gameObject.AddComponent<TrailsEffect>();
                trailsDic[GetSkillCode(tran.name)].Init();
            }
        }

        private int GetSkillCode(string codeName)
        {
            SkillCodeMudule skillCode = new SkillCodeMudule();
            return skillCode.GetSkillCode(codeName,prefixName,"");
        }

        private void HideAllTrails()
        {
            foreach (KeyValuePair<int,TrailsEffect> pair in trailsDic)
            {
                pair.Value.HideNow();
            }
        }

        private void ShowOrHideTrails(TrailsEffect effect,bool isActive)
        {
            if(isActive)
            {
                effect.Show();
            }
            else
            {
                effect.Hide();
            }
        }

        private void HideTrails(int code)
        {
            ShowOrHideTrails(trailsDic[code], false);
        }

        private void ShowTrails(int code)
        {
            ShowOrHideTrails(trailsDic[code], true);
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
