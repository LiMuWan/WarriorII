using Const;
using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame
{
    public class MainMenuButtonEffect : UIEffectBase   
    {
        public override void Enter()
        {
            base.Enter();
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(new Vector2(0, -328), 1);
        }
        public override void Exit()
        {
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(defaultAnchorPos, 1);
        }

        public override UiEffect GetUIEffectLevel()
        {
            return UiEffect.VIEW_EFFECT;
        }

    }
}
