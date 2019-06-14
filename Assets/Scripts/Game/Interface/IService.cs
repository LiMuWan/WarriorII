using UnityEngine;

namespace Game.Interface
{
    public interface IService 
    {
        void Init(Contexts contexts);
        void Update();
    }
}
