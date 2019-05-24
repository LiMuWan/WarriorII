using Const;
using DG.Tweening;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class BtnSelected : MonoBehaviour    
    {
        public SelectedState SelectedState { get; set; }

        public int Index
        {
            get
            {
                return transform.GetSiblingIndex(); //��ȡ���������ֵܽڵ����ǵڼ�������ʵ�����ڸ������µĵڼ���
            }
        }

        private Color defaultColor;
        public void Selected()
        {
            if (!JudgeException(transform))
            {
                SaveDefaultColor(transform);
                PlayEffect(transform);
            }
        }

        public void CancelSelected()
        {
            KillEffect(transform);
        }

        private void KillEffect(Transform btn)
        {
            if (btn == null)
                return;

            btn.Image().DOKill();
            btn.Image().color = defaultColor;
        }

        private bool JudgeException(Transform btn)
        {
            return btn.Button() == null || btn.Image() == null;
        }

        private void SaveDefaultColor(Transform btn)
        {
               defaultColor = btn.Image().color;
        }

        private void PlayEffect(Transform btn)
        {
            btn.Image().DOColor(new Color(47, 85, 214, 255), 0.5f).SetLoops(-1, LoopType.Yoyo);
        }

       
    }
}
