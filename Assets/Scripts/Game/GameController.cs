﻿using Entitas;
using Game.View;
using Manager;
using Manager.Parent;
using UnityEngine;
using Util;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        private Contexts contexts;
        private IServiceManager serviceManager;

        public void Awake()
        {
            contexts = Contexts.sharedInstance;
            InitManager();

            systems = new InitFeature(Contexts.sharedInstance);

            systems.Initialize();

            contexts.game.SetGameGameState(GameState.START);//发出游戏开始事件 

        }

        private void InitManager()
        {
            var gameParentManager = transform.GetOrAddComponent<GameParentManager>();
            gameParentManager.Init();

            var cameraControllerTrans = gameParentManager.GetParentTrans(ParentName.CameraController);
            CameraController cameraController = cameraControllerTrans.gameObject.AddComponent<CameraController>();

            var entity = contexts.game.CreateEntity();
            entity.AddGameCameraState(CameraAniName.NONE);
            cameraController.Init(contexts, entity);

            var uiControllerTrans = gameParentManager.GetParentTrans(ParentName.UIController);
            UIController uiController = uiControllerTrans.gameObject.AddComponent<UIController>();
            uiController.Init();

            ModelManager.Single.Init();

            serviceManager = new ServiceManager(gameParentManager);
            serviceManager.Init(contexts);

            LoadAudioManager.Single.Init();
        }

        private void Update()
        {
            systems.Execute();//每一帧执行
            systems.Cleanup();//每一帧执行完之后调用
            serviceManager.Execute();
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
