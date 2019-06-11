using Entitas;
using Manager;
using Manager.Parent;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 加载服务接口
    /// </summary>
    public interface ILoadService:ILoad
    {
        IPlayerBehaviour LoadPlayer();
    }

    public class LoadService : ILoadService
    {
        private GameParentManager parentManager;

        public LoadService(GameParentManager parentManager)
        {
            this.parentManager = parentManager;
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

        public IPlayerBehaviour LoadPlayer()
        {
           var player = LoadManager.Single.LoadAndInstantiate(Path.PLAYER_PATH, parentManager.GetParentTrans(ParentName.PlayerRoot));
           PlayerView playerView = player.AddComponent<PlayerView>();

           GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
           entity.AddGamePlayer(playerView);
           playerView.Init(Contexts.sharedInstance,entity);
           return playerView;
        }
    }
}
