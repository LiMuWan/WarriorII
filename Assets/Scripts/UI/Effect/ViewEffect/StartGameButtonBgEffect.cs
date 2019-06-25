using Const;
using UnityEngine;
using DG.Tweening;

namespace UIFrame
{
    public class StartGameButtonBgEffect : UIEffectBase   
    {
        public override void Enter()
        {
            base.Enter();
            transform.DOKill();
            transform.DOScaleY(1, 0.5f);
        }
        public override void Exit()
        {
            transform.DOKill();
            transform.DOScaleY(0, 0.5f);
        }

        public override UiEffect GetUIEffectLevel()
        {
            return UiEffect.VIEW_EFFECT;
        }

    }
}
