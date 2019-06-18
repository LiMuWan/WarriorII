using Entitas;
using Game.Interface;
using Module.Timer;
using UnityEngine;

namespace Game.Service
{
    public interface ITimerService:IInitService,IExecuteService,ITimeManager
    {

    }
    public class TimerService :ITimerService
    {
        private ITimeManager timeManager;
        
        public TimerService(ITimeManager manager)
        {
            this.timeManager = manager;
        }

        public void Init(Contexts contexts)
        {
            contexts.service.SetGameServiceTimerService(this);
        }

        public void Execute()
        {
            Update();
        }

        public int GetPriority()
        {
            return 0;
        }

        public ITimer CreateTimer(float duration, bool loop)
        {
            return timeManager.CreateTimer(duration, loop);
        }
 
        public void ContinueAll()
        {
            timeManager.ContinueAll();
        }

        public void PauseAll()
        {
            timeManager.ContinueAll();
        }

        public void StopAll()
        {
            timeManager.StopAll();
        }

        public void Update()
        {
            timeManager.Update();
        } 
    }
}
