using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// ���ҳ���������ķ���ӿ�
    /// </summary>
    public interface IFindObjectService:IInitService
    {
        T[] FindAllType<T>() where T : Object;
        IView[] FindAllView();
    }

    /// <summary>
    ///  ���ҳ���������ķ���
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public T[] FindAllType<T>() where T : Object
        {
            T[] temp = Object.FindObjectsOfType<T>(); 
            if(temp == null || temp.Length == 0)
            {
                Debug.LogError("δ�ҵ����� ��" + typeof(T).FullName + "����");
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
