using UnityEngine;

namespace Game
{
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
    }
}
