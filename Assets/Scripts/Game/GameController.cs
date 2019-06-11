using Entitas;
using Manager.Parent;
using UnityEngine;
using Util;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        private GameParentManager gameParentManager;
        public void Start()
        {
            InitManager();

            Services services = new Services(new FindObjectService(),
                                        new EntitasInputService(),
                                        new UnityInputService(),
                                        new LogService(),
                                        new LoadService(gameParentManager));

            systems = new InitFeature(Contexts.sharedInstance,services);

            systems.Initialize();

            Contexts.sharedInstance.game.SetGameGameState(GameState.START);//发出游戏开始事件 
        }

        private void InitManager()
        {
            gameParentManager = transform.GetOrAddComponent<GameParentManager>();
            gameParentManager.Init();

            var cameraController = gameParentManager.GetParentTrans(ParentName.CameraController);
            cameraController.gameObject.AddComponent<CameraController>();
            //get CameraController
            //get 
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
