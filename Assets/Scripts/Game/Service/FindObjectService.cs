using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 查找场景内物体的服务接口
    /// </summary>
    public interface IFindObjectService:IInitService
    {
        T[] FindAllType<T>() where T : Object;
        IView[] FindAllView();
    }

    /// <summary>
    ///  查找场景中物体的服务
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public T[] FindAllType<T>() where T : Object
        {
            T[] temp = Object.FindObjectsOfType<T>(); 
            if(temp == null || temp.Length == 0)
            {
                Debug.LogError("未找到类型 ：" + typeof(T).FullName + "对象");
            }
            return temp;
        }

        public IView[] FindAllView()
        {
           var array = FindAllType<ViewService>();
           return array;
        }

        public int GetPriority()
        {
            return 0;
        }

        public void Init(Contexts contexts)
        {
            contexts.game.SetGameComponentFindObjectService(this);
        }
    }
}
