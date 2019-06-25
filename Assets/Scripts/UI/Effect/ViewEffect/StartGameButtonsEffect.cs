using Const;
using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame
{
    public class StartGameButtonsEffect : UIEffectBase    
    {
        public override void Enter()
        {
            base.Enter();
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(new Vector2(22, 234), 1);
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
