using System.Collections.Generic;
using Entitas;
using Game.Effect;
using UnityEngine;

namespace Game.View
{
    public class TrailComboManager:ViewBase,IGameStartHumanSkillListener
    {
        private string prefixName = "trail_";
        private Dictionary<int, TrailsEffect> trailsDic;
        private Dictionary<int, float> clipLengthDic;
        private SkillCodeMudule codeMudule;

        public override void Init(Contexts contexts, IEntity entity)
        {
            base.Init(contexts, entity);
            GameEntity gameEntity = entity as GameEntity;
            gameEntity.AddGameStartHumanSkillListener(this);
            trailsDic = new Dictionary<int, TrailsEffect>();
            clipLengthDic = new Dictionary<int, float>();
            codeMudule = new SkillCodeMudule();
        }

        public void Init(Contexts contexts, IEntity entity,Animator animator)
        {
            Init(contexts, entity);

            InitClipLengthDic(animator);
            InitTrailsDic();
            HideAllTrails();
        }

        private void InitClipLengthDic(Animator animator)
        {
            var clips = animator.runtimeAnimatorController.animationClips;
            int code = 0;
            foreach (AnimationClip clip in clips)
            {
                code = codeMudule.GetSkillCode(clip.name, Const.ConstValue.SKILL_ANI_PREFIX, "");
                if (code < 0) continue;
                clipLengthDic[code] = clip.length;
            }
        }

        private void InitTrailsDic()
        {
            int code = 0;
            float length = 0;
            foreach (Transform tran in transform)
            {
                code = GetSkillCode(tran.name);
                if (clipLengthDic.ContainsKey(code))
                {
                    length = clipLengthDic[code];
                    trailsDic[GetSkillCode(tran.name)] = tran.gameObject.AddComponent<TrailsEffect>();
                    trailsDic[GetSkillCode(tran.name)].Init(length);
                }
                else
                {
                    Debug.LogWarning("动画中未找到对应code ==" + code + "的动画片段");
                    trailsDic[code] = tran.gameObject.AddComponent<TrailsEffect>();
                    trailsDic[code].Init(0);
                }
            }
        }

        private int GetSkillCode(string codeName)
        {
            return codeMudule.GetSkillCode(codeName,prefixName,"");
        }

        private void HideAllTrails()
        {
            foreach (KeyValuePair<int,TrailsEffect> pair in trailsDic)
            {
                pair.Value.HideNow();
            }
        }

        private void ShowTrails(int code)
        {
            trailsDic[code].Show();
        }

        public void OnGameStartHumanSkill(GameEntity entity, int SkillCode)
        {
            ShowTrails(SkillCode);
        }
    }
}
