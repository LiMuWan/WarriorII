using Entitas;
using UnityEngine;

namespace Game
{
    public interface IView   
    {
        void Init(Contexts contexts,IEntity entity);
    }
}
