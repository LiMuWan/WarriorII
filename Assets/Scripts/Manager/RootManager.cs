using Const;
using System;
using System.Collections.Generic;
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
            uiManager.AddInitBtnParentCallBack((uiTrans) =>
            {
                List<Transform> btnParents = uiManager.GetBtnParents(uiTrans);
                btnStateManager.InitBtnParent(btnParents);
             });
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

        public void ButtonLeft()
        {
            btnStateManager.Left();
        }

        public void ButtonRight()
        {
            btnStateManager.Right();
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
            btnStateManager.Show(uiParam.Item1);
        }

        public void SelectedButton()
        {
            btnStateManager.SelectedButton();
        }
    }
}
