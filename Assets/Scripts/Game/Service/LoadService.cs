using Entitas;
using Game.Interface;
using Manager;
using Manager.Parent;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 加载服务接口
    /// </summary>
    public interface ILoadService:ILoad,IService
    {
        void LoadPlayer();
    }

    public class LoadService : ILoadService
    {
        private GameParentManager parentManager;

        public LoadService(GameParentManager parentManager)
        {
            this.parentManager = parentManager;
        }

        public void Init(Contexts contexts)
        {
            contexts.game.SetGameLoadService(this);
        }

        public T Load<T>(string path, string name) where T : class
        {
           return LoadManager.Single.Load<T>(path, name);
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return LoadManager.Single.LoadAll<T>(path);
        }

        public GameObject LoadAndInstantiate(string path, Transform parent)
        {
            return LoadManager.Single.LoadAndInstantiate(path, parent);
        }

        public void LoadPlayer()
        {
            var player = LoadManager.Single.LoadAndInstantiate(Path.PLAYER_PATH, parentManager.GetParentTrans(ParentName.PlayerRoot));
            Animator animator = player.GetComponent<Animator>();

            IView playerView = player.AddComponent<PlayerView>();
            IPlayerBehaviour playerBehaviour = new PlayerBehaviour(player.transform, ModelManager.Single.PlayerData);
            IPlayerAni playerAni = null;

            if (animator == null)
            {
                Debug.LogError("player身上未找到Animator组件！！！");
            }
            else
            {
                playerAni = new PlayerAni(animator);
            }

            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddGamePlayer(playerView, playerBehaviour, playerAni);
            entity.AddGamePlayerAniState(Const.PlayerAniIndex.IDLE);
            playerView.Init(Contexts.sharedInstance, entity);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
