using Manager;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 加载服务接口
    /// </summary>
    public interface ILoadService:ILoad
    {       
    }

    public class LoadService : ILoadService
    {
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
    }
}
