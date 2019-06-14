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

            Services services = new Services(new FindObjectService(),
                                        new EntitasInputService(),
                                        new UnityInputService(),
                                        new LogService(),
                                        new LoadService(gameParentManager),
                                        new TimerService(contexts));

            systems = new InitFeature(Contexts.sharedInstance,services);

            systems.Initialize();

            contexts.game.SetGameGameState(GameState.START);//������Ϸ��ʼ�¼� 
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
            systems.Execute();//ÿһִ֡��
            systems.Cleanup();//ÿһִ֡����֮�����
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
