using System;
using UnityEngine;

namespace UIFrame
{
    public class UIEffectManager : MonoBehaviour    
    {
        public void Show(Transform ui)
        {
            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                effect.Enter();
            }
        }

        public void Hide(Transform ui)
        {
            foreach (var effect in ui.GetComponentsInChildren<UIEffectBase>(true))
            {
                effect.Exit();
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
