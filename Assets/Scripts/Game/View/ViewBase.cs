using Entitas;
using Entitas.Unity;
using Game.Interface;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// View ����� 
    /// </summary>
    public abstract class ViewBase : MonoBehaviour,IView    
    {
        public virtual void Init(Contexts contexts,IEntity entity)
        {
            gameObject.Link(entity, contexts.game);//Ϊʲô�ظ����벻д�ڻ��࣬��Ϊ��֪��contexts��û�а취֪����
        }

    }
}
