using Const;
using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame
{
    public class WarningEffect : UIEffectBase   
    {
        public override void Enter()
        {
            base.Enter();
            Init();
            transform.RectTransform().DOAnchorPos(Vector2.zero, 1f); 
        }

        private void Init()
        {
            defaultAnchorPos = new Vector2(1640, 0);
            transform.RectTransform().anchoredPosition = defaultAnchorPos;
        }

        public override void Exit()
        {
            transform.RectTransform().DOAnchorPos(defaultAnchorPos, 1f);
        }

        public override UiEffect GetUIEffectLevel()
        {
            return UiEffect.VIEW_EFFECT;
        }

    }
}
