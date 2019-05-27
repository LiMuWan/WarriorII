using Const;
using UnityEngine;
using DG.Tweening;
using Util;

namespace UIFrame
{
    public class GameNameEffect : UIEffectBase   
    {
        public override void Enter()
        {
            base.Enter();
            float time = 1;
            transform.DOKill();
            transform.RectTransform().DOKill();
            transform.DOScale(Vector3.one * 2f, time);
            transform.RectTransform().DOAnchorPos(defaultAnchorPos, time).OnComplete(() => onExitComplete?.Invoke()); 
        }

        public override void Exit()
        {
            float time = 1;
            transform.DOKill();
            transform.RectTransform().DOKill();
            transform.DOScale(Vector3.one * 1.5f, time);
            transform.RectTransform().DOAnchorPos(new Vector2(514, 193), time).OnComplete(() => onEnterComplete?.Invoke());
        }

        public override UiEffect GetUIEffectLevel()
        {
            return UiEffect.VIEW_EFFECT;
        }
    }
}
