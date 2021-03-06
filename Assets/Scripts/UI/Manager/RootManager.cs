﻿using Const;
using Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class RootManager : MonoBehaviour
    {
        private UIManager uiManager;
        private UIEffectManager uiEffectManager;
        private UILayerManager uiLayerManager;
        private InputManager inputManager;
        private BtnStateManager btnStateManager;
        private UIAudioManager audioManager;

        public static RootManager Instance;
        private void Awake()
        {
            Instance = this;
            uiManager = gameObject.AddComponent<UIManager>();
            uiEffectManager = gameObject.AddComponent<UIEffectManager>();
            uiLayerManager = gameObject.AddComponent<UILayerManager>();
            inputManager = gameObject.AddComponent<InputManager>();
            btnStateManager = gameObject.AddComponent<BtnStateManager>();
            audioManager = gameObject.AddComponent<UIAudioManager>();

            uiManager.AddGetLayerObjectListener(uiLayerManager.GetLayerObject);
            uiManager.AddInitBtnParentCallBack((uiTrans) =>
            {
                List<Transform> btnParents = uiManager.GetBtnParents(uiTrans);
                btnStateManager.InitBtnParent(btnParents);
             });
            audioManager.Init(Path.UI_AUDIO_PATH, LoadManager.Single.LoadAll<AudioClip>);

            audioManager.PlayBG(UIAudioName.UI_bg.ToString());
        }

        private void Start()
        {
            Show(UiId.MainMenu);
        }

        public void Back()
        {
            var uiParam = uiManager.Back();
            ExcuteEffect(uiParam);
            ShowBtnState(uiManager.GetCurrentUITransform());
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
            ShowBtnState(uiParam.Item1);
        }

        private void ExcuteEffect(Tuple<Transform,Transform> uiParam)
        {
            ShowUI(uiParam.Item1);
            HideUI(uiParam.Item2);
        }

        private void ShowUI(Transform showUI)
        {
            ShowUIEffect(showUI);
            ShowUIAudio();
        }

        private void HideUI(Transform hideUI)
        {
            HideUIEffect(hideUI);
            HideUIAudio();
        }

        private void ShowUIAudio()
        {
            audioManager.Play(UIAudioName.UI_in.ToString());
        }

        private void HideUIAudio()
        {
            audioManager.Play(UIAudioName.UI_out.ToString());
        }

        private void ShowUIEffect(Transform showUI)
        {
            if (showUI == null)
            {
                uiEffectManager.ShowOthersEffect(uiManager.GetBasicUITransform());
            }
            else
            {
                uiEffectManager.Show(showUI);
            }
        }

        private void HideUIEffect(Transform hideUI)
        {
            if (hideUI == null)
            {
                uiEffectManager.HideOthersEffect(uiManager.GetBasicUITransform());
            }
            else
            {
                uiEffectManager.Hide(hideUI);
            }
        }

        public void SelectedButton()
        {
            btnStateManager.SelectedButton();
        }

        public void ShowBtnState(Transform uiTransform)
        {
            btnStateManager.Show(uiTransform);
        }

        public void PlayUIAudio(UIAudioName uIAudioName)
        {
            audioManager.Play(uIAudioName.ToString());
        }
    }
}
