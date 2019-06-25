using Const;
using UnityEngine;
using DG.Tweening;
using Util;

namespace UIFrame
{
    public class StartGameTitleEffect : UIEffectBase    
    {
        public override void Enter()
        {
            base.Enter();
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(new Vector2(15, -19), 1);
        }

        public override void Exit()
        {
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(defaultAnchorPos, 1);
        }

        public override UiEffect GetUIEffectLevel()
        {
            return UiEffect.OTHER_EFFECT;
        }

    }
}
