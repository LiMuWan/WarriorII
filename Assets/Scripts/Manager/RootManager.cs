using Const;
using System;
using UnityEngine;

namespace UIFrame
{
    public class RootManager : MonoBehaviour
    {
        private UIManager uiManager;
        private UIEffectManager uiEffectManager;
        private UILayerManager uiLayerManager;
        private InputManager inputManager;
        private BtnStateManager btnStateManager;

        public static RootManager Instance;
        private void Awake()
        {
            Instance = this;
            uiManager = gameObject.AddComponent<UIManager>();
            uiEffectManager = gameObject.AddComponent<UIEffectManager>();
            uiLayerManager = gameObject.AddComponent<UILayerManager>();
            inputManager = gameObject.AddComponent<InputManager>();
            btnStateManager = gameObject.AddComponent<BtnStateManager>();

            uiManager.AddGetLayerObjectListener(uiLayerManager.GetLayerObject);
        }

        private void Start()
        {
            Show(UiId.MainMenu);
        }

        public void Back()
        {
            var uiParam = uiManager.Back();
            ExcuteEffect(uiParam);
        }

        public void Show(UiId uiId)
        {
            var uiParam = uiManager.Show(uiId);
            ExcuteEffect(uiParam);
        }

        private void ExcuteEffect(Tuple<Transform,Transform> uiParam)
        {
            if (uiParam == null) return;

            uiEffectManager.Show(uiParam.Item1);
            uiEffectManager.Hide(uiParam.Item2);

            btnStateManager.CurrentParents = uiManager.GetBtnParents(uiParam.Item1);
        }
    }
}
