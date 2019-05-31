using System;
using UIFrame;
using UnityEngine;

namespace Manager
{
    public class UIEffectManager : MonoBehaviour    
    {
        public void Show(Transform ui)
        {
            if (ui == null) return;

            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                effect.Enter();
            }
        }

        public void Hide(Transform ui)
        {
            if (ui == null) return;

            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                effect.Exit();
            }
        }

        public void HideOthersEffect(Transform ui)
        {
            if (ui == null) return;

            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                if (effect.GetUIEffectLevel() == Const.UiEffect.OTHER_EFFECT)
                {
                    effect.Exit();
                }
            }
        }

        public void ShowOthersEffect(Transform ui)
        {
            if (ui == null) return;

            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                if (effect.GetUIEffectLevel() == Const.UiEffect.OTHER_EFFECT)
                {
                    effect.Enter();
                }
            }
        }

        public void AddViewEffectEnterListener(Transform ui,Action enterComplete)
        {
            foreach (var effectBase in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                if(effectBase.GetUIEffectLevel() == Const.UiEffect.VIEW_EFFECT)
                {
                    effectBase.OnEnterComplete(enterComplete);
                }
            }
        }

        public void AddViewEffectExitListener(Transform ui, Action exitComplete)
        {
            foreach (var effectBase in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                if (effectBase.GetUIEffectLevel() == Const.UiEffect.VIEW_EFFECT)
                {
                    effectBase.OnExitComplete(exitComplete);
                }
            }
        }
    }
}
