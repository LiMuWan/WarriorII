using Entitas;
using UnityEngine;

namespace Game.Interface
{
    public interface IView
    {
        void Init(Contexts contexts, IEntity entity);
    }
}
