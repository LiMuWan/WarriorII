using Entitas;
using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public abstract class ViewService : MonoBehaviour,IView    
    {
        public abstract void Init(Contexts contexts,IEntity entity);

    }
}
