using UnityEngine;

namespace Game.Interface
{
    public interface IInitService 
    {
        void Init(Contexts contexts);
    }

    public interface IExcuteService
    {
        void Excute();
    }
}
