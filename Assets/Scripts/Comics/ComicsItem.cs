using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame
{
    public class ComicsItem : MonoBehaviour    
    {
        public int Page { get; private set; }
        public void Init(Sprite sprite,int page)
        {
            if(transform.Image() != null)
            {
                transform.Image().sprite = sprite;
            }

            this.Page = page;
        }

        private void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void SetParentAndPosition(Transform parent)
        {
            transform.SetParent(parent);
            transform.RectTransform().anchoredPosition = Vector2.zero;
        }

        public void Move(Transform parent)
        {
            SetParent(parent);
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(Vector2.zero, 1f).SetEase(Ease.Linear);
        }
    }
}
