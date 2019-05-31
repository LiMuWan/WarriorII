using UnityEngine;

namespace Game
{
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
    }
}
