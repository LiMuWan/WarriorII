using Entitas;
using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public interface ITimerService:IInitService,IExcuteService
    {

    }
    public class TimerService :ITimerService
    {
        public TimerService(Contexts contexts)
        {

        }

        public void Excute()
        {
            throw new System.NotImplementedException();
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
