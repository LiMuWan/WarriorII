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
        public TimerService()
        {
           
        }

        public void Init(Contexts contexts)
        {
            contexts.game.SetGameComponentTimerService(this);
        }

        public void Execute()
        {
            
        }

        public int GetPriority()
        {
            return 0;
        }
    }
}
