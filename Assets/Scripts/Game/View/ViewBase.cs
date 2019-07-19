using Entitas;
using Entitas.Unity;
using Game.Interface;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// View 层基类 
    /// </summary>
    public abstract class ViewBase : MonoBehaviour,IView    
    {
        protected GameEntity gameEntity;
        public virtual void Init(Contexts contexts,IEntity entity)
        {
            gameObject.Link(entity, contexts.game);//为什么重复代码不写在基类，因为不知道contexts是没有办法知道的

            if(entity is GameEntity)
            {
                gameEntity = (GameEntity)entity;
            }
        }

    }
}
