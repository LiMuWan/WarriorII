using UnityEngine;

namespace Game.Interface
{
    public interface IInitService 
    {
        void Init(Contexts contexts);
    }

    public interface IExecuteService
    {
        void Execute();
    }
}
