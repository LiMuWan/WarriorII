using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TrailComboManager:MonoBehaviour     
    {
        private string prefixName = "trail_";
        private Dictionary<int, Transform> trailsDic;

        public void Init()
        {
            trailsDic = new Dictionary<int, Transform>();
            InitTrailsDic();
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

    }
}
