using Entitas;
using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public interface ITimerService:IService
    {

    }
    public class TimerService : IExecuteSystem, ITimerService
    {
        public TimerService(Contexts contexts)
        {

        }
        public void Execute()
        {
           
        }

        public void Init(Contexts contexts)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
