using UnityEngine;
using Util;

namespace Manager
{
    public class LoadManager:SingletonBase<LoadManager>    
    {
        public T Load<T>(string path,string name) where T: class
        {
           return Resources.Load(path + name) as T;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
           return Resources.LoadAll<T>(path);
        }

        public GameObject LoadAndInstantiate(string path , Transform parent)
        {
            var temp = Resources.Load<GameObject>(path);
            if(temp == null)
            {
                Debug.LogError("can not find the gameobject : " + temp.name + "under the path : " + path);
                return null;
            }
            else
            {
                return GameObject.Instantiate(temp,parent);
            }
        }
    }
}
