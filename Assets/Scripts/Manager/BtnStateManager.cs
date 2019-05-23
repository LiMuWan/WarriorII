using System.Collections.Generic;
using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame
{
    public class BtnStateManager : MonoBehaviour    
    {
        private Dictionary<Transform, Color> defaultColorDic = new Dictionary<Transform, Color>();

        private Transform lastBtnTrans;

        private List<Transform> currentParents = new List<Transform>();

        public List<Transform> CurrentParents
        {
            set
            {
                JudgeException(value);
                currentParents = value;
                SetDefaultBtn(value);
            }
        }
        

        private bool JudgeException(List<Transform> parents)
        {
            return parents == null || parents.Count == 0;
        }

        public void SetDefaultBtn(List<Transform> parents)
        {
            if(parents[0].childCount > 0)
            {
                Selected(parents[0].GetChild(0));
            }
        }

        private void Selected(Transform trans)
        {
            KillEffect(lastBtnTrans);
            if (!JudgeException(trans))
            {
                SaveDefaultColor(trans);
                PlayEffect(trans);
            }
            lastBtnTrans = trans;
        }
        private bool JudgeException(Transform btn)
        {
            return btn.Button() == null || btn.Image() == null;
        }

        private void SaveDefaultColor(Transform btn)
        {
            if(!defaultColorDic.ContainsKey(btn))
            {
                defaultColorDic[btn] = btn.Image().color;
            }
        }

        private void PlayEffect(Transform btn)
        {
           btn.Image().DOColor(new Color(47, 85, 214, 255),0.5f).SetLoops(-1,LoopType.Yoyo);
        }

        private void KillEffect(Transform btn)
        {
            if (btn == null)
                return;

            btn.Image().DOKill();
            if(defaultColorDic.ContainsKey(btn))
            {
                btn.Image().color = defaultColorDic[btn];
            }
        }
    }
}
