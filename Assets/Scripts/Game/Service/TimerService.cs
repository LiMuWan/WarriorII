using Const;
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

        public ITimer CreateTimer(TimerId timerId,float duration,bool loop)
        {
            return timeManager.CreateTimer(timerId, duration,loop);
        }

        public ITimer GetTimer(TimerId timerid)
        {
            return timeManager.GetTimer(timerid);
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

        public ITimer CreateTimer(string id, float duration, bool loop)
        {
            return  timeManager.CreateTimer(id, duration, loop);
        }

        public ITimer GetTimer(string id)
        {
            return timeManager.GetTimer(id);
        }

        public ITimer ResetTimerData(string id, float duration, bool loop)
        {
             return timeManager.ResetTimerData(id, duration, loop);
        }

        public ITimer ResetTimerData(TimerId id, float duration, bool loop)
        {
            return  timeManager.ResetTimerData(id, duration, loop);
        }
    }
}
