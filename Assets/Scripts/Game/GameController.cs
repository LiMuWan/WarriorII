using Entitas;
using Game.Service;
using Manager;
using Manager.Parent;
using UnityEngine;
using Util;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        private GameParentManager gameParentManager;
        private Contexts contexts;
        public void Start()
        {
            contexts = Contexts.sharedInstance;
            InitManager();

            var services = InitService();

            systems = new InitFeature(Contexts.sharedInstance,services);

            systems.Initialize();

            contexts.game.SetGameGameState(GameState.START);//发出游戏开始事件 
        }

        private Services InitService()
        {
            Services services = new Services();
            AddInitService(services);
            AddExecuteService(services);
            return services;
        }

        private void AddInitService(Services services)
        {
            services.AddInitService(new FindObjectService());
            services.AddInitService(new LogService());
            services.AddInitService(new LoadService(gameParentManager));
            services.AddInitService(new TimerService(contexts));
            services.AddInitService(new EntitasInputService());
            services.AddInitService(new UnityInputService());
        }

        private void AddExecuteService(Services services)
        {
            services.AddExecuteService(new EntitasInputService());
            services.AddExecuteService(new UnityInputService());
            services.AddExecuteService(new TimerService(contexts));
        }
        private void InitManager()
        {
            gameParentManager = transform.GetOrAddComponent<GameParentManager>();
            gameParentManager.Init();

            var cameraControllerTrans = gameParentManager.GetParentTrans(ParentName.CameraController);
            CameraController cameraController = cameraControllerTrans.gameObject.AddComponent<CameraController>();
            var entity = contexts.game.CreateEntity();
            entity.AddGameCameraState(CameraAniName.NONE);
            cameraController.Init(contexts, entity);

            ModelManager.Single.Init(); 
        }

        private void Update()
        {
            systems.Execute();//每一帧执行
            systems.Cleanup();//每一帧执行完之后调用
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
