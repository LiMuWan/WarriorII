using Const;
using DG.Tweening;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class BtnSelected : MonoBehaviour    
    {
        public SelectedState SelectedState
        {
            set
            {
                switch (value)
                {
                    case SelectedState.SELECTED:
                        Selected();
                        break;
                    case SelectedState.UNSELECTED:
                        CancelSelected();
                        break;
                }
            }
        }

        public int Index
        {
            get
            {
                return transform.GetSiblingIndex(); //获取它在它的兄弟节点中是第几个，其实就是在父物体下的第几个
            }
        }

        private Color defaultColor;

        private void Awake()
        {
            SaveDefaultColor(transform);
        }
        public void Selected()
        {
            if (!JudgeException(transform))
            {    
                PlayEffect(transform);
            }
        }

        public void CancelSelected()
        {
            KillEffect(transform);
        }

        public  void SelectedButton()
        {
            transform.Button().onClick.Invoke();
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
