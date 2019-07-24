using Const;
using Entitas;
using Game.Interface;
using Module.Timer;
using UnityEngine;

namespace Game.Service
{
    public interface ITimerService:IInitService,IExecuteService,ITimeManager
    {
        /// <summary>
        /// 创建计时器,如果当前指定计时器正在计时，返回null
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(TimerId timerId, float duration, bool loop);

        /// <summary>
        /// 重置某个正在播放的Timer数据
        /// </summary>
        /// <param name="timerId"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        ITimer ResetTimerData(TimerId timerId, float duration, bool loop);

        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        ITimer GetTimer(TimerId timerId);

        /// <summary>
        /// 指定ID的timer为空，创建timer,不为空，重新启动timer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateOrRestartTimer(TimerId timerId, float duration, bool loop);

    }
    public class TimerService :ITimerService
    {
        private ITimeManager timerManager;
        
        public TimerService(ITimeManager manager)
        {
            this.timerManager = manager;
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
            return timerManager.CreateTimer(timerId.ToString(), duration,loop);
        }

        public ITimer GetTimer(TimerId timerid)
        {
            return timerManager.GetTimer(timerid.ToString());
        }

        public void ContinueAll()
        {
            timerManager.ContinueAll();
        }

        public void PauseAll()
        {
            timerManager.ContinueAll();
        }

        public void StopAll()
        {
            timerManager.StopAll();
        }

        public void Update()
        {
            timerManager.Update();
        }

        public ITimer CreateTimer(string timerId, float duration, bool loop)
        {
            return  timerManager.CreateTimer(timerId, duration, loop);
        }

        public ITimer GetTimer(string timerId)
        {
            return timerManager.GetTimer(timerId);
        }

        public ITimer ResetTimerData(string timerId, float duration, bool loop)
        {
             return timerManager.ResetTimerData(timerId, duration, loop);
        }

        public ITimer ResetTimerData(TimerId timerId, float duration, bool loop)
        {
            return  timerManager.ResetTimerData(timerId.ToString(), duration, loop);
        }

        public ITimer CreateOrRestartTimer(string timerId, float duration, bool loop)
        {
            return timerManager.CreateOrRestartTimer(timerId, duration, loop);
        }

        public ITimer CreateOrRestartTimer(TimerId timerId, float duration, bool loop)
        {
            return timerManager.CreateOrRestartTimer(timerId.ToString(), duration, loop);
        }

        public void StopTimer(ITimer timer, bool isComplete)
        {
            timerManager.StopTimer(timer, isComplete);
        }
    }
}
