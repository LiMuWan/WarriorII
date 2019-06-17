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
        private Contexts contexts;
        private IServiceManager serviceManager;
        public void Start()
        {
            contexts = Contexts.sharedInstance;
            InitManager();

            systems = new InitFeature(Contexts.sharedInstance);

            systems.Initialize();

            contexts.game.SetGameGameState(GameState.START);//������Ϸ��ʼ�¼� 
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

            ModelManager.Single.Init();

            serviceManager = new ServiceManager(gameParentManager);
            serviceManager.Init(contexts);
        }

        private void Update()
        {
            systems.Execute();//ÿһִ֡��
            systems.Cleanup();//ÿһִ֡����֮�����
            serviceManager.Execute();
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
