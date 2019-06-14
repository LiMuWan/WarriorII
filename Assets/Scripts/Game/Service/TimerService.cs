using Entitas;
using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public interface ITimerService:IInitService,IExecuteService
    {

    }
    public class TimerService :ITimerService
    {
        public TimerService(Contexts contexts)
        {
           
        }

        public void Init(Contexts contexts)
        {
            contexts.game.SetGameComponentTimerService(this);
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
