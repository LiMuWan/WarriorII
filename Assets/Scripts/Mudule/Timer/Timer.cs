﻿using Const;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Module.Timer
{
    public interface ITimer
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        string ID { get; }
        /// <summary>
        /// 当前的时间
        /// </summary>
        float CurrentTime { get; }
        /// <summary>
        /// 运行百分比
        /// </summary>
        float Percent { get; }
        /// <summary>
        /// 单次循环持续时间 
        /// </summary>
        float Duration { get; }
        /// <summary>
        /// 是否循环
        /// </summary>
        bool Isloop { get; }
        /// <summary>
        /// 是否完成
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// 是否正在计时
        /// </summary>
        bool IsTiming { get;}
        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();
        /// <summary>
        /// 继续计时
        /// </summary>
        void Continue();
        /// <summary>
        /// 暂停计时
        /// </summary>
        void Pause();
        /// <summary>
        /// 停止计时
        /// </summary>
        void Stop(bool isComplete);
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(string timerId, float duration, bool loop);

        ITimer AddUpdateListener(Action onUpdate);
        ITimer AddCompleteListener(Action onComplete);
    }
   
    public interface ITimeManager
    {
        /// <summary>
        /// 创建计时器,如果当前指定计时器正在计时，返回null
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(string timerId, float duration, bool loop);

        /// <summary>
        /// 重置指定ID的Timer数据
        /// </summary>
        /// <param name="timerId"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        ITimer ResetTimerData(string timerId, float duration, bool loop);

        /// <summary>
        /// 指定ID的timer为空，创建timer,不为空，重新启动timer
        /// </summary>
        /// <param name="timerId"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateOrRestartTimer(string timerId, float duration, bool loop);

 
        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        ITimer GetTimer(string timerId);

     
        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();

        /// <summary>
        /// 停止某个计时器
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="isComplete"></param>
        void StopTimer(ITimer timer, bool isComplete);

        /// <summary>
        /// 继续执行所有计时器
        /// </summary>
        void ContinueAll();

        /// <summary>
        /// 暂停所有计时器
        /// </summary>
        void PauseAll();

        /// <summary>
        /// 关闭所有计时器
        /// </summary>
        void StopAll();
    }

    public class TimerManager:ITimeManager
    {
        /// <summary>
        /// 计时器
        /// </summary>
        private class Timer : ITimer
        {
            /// <summary>
            /// 唯一标识
            /// </summary>
            public string ID { get; private set; }
            /// <summary>
            /// 当前的时间
            /// </summary>
            public float CurrentTime { get { return runTimeTotal; } }
            /// <summary>
            /// 运行百分比
            /// </summary>
            public float Percent { get { return runTimeTotal / duration; } }
            /// <summary>
            /// 单次循环持续时间 
            /// </summary>
            public float Duration { get { return duration; } }
            //是否循环执行
            public bool Isloop { get; private set; }

            //是否完成
            public bool IsComplete { get; private set; }

            private Action onUpdate;
            private Action onComplete;

            //是否正在计时
            public bool IsTiming { get; private set; }
          
            //计时开始时间
            private DateTime startTime;
            //总运行时间
            private float runTimeTotal;
          
            //持续时间 
            private float duration;

            private int offsetFrame = 20;
            private int frameTimes = 0;
            public void Update()
            {
                frameTimes++;
                if (frameTimes < offsetFrame)
                    return;
                else frameTimes = 0;
         
                if (IsComplete || !IsTiming)
                    return;
                IsComplete = JudgeIsComplete();
                if (Isloop)
                {
                    Loop();
                }
                else
                {
                    NotLoop();
                }

                onUpdate?.Invoke();
            }

            /// <summary>
            /// 持续时间单位为秒
            /// </summary>
            /// <param name="duration"></param>
            public Timer(string timerId, float duration, bool loop)
            {
                InitData(timerId, duration, loop);
            }

            private void InitData(string timerId, float duration, bool loop)
            {
                this.ID = timerId;
                this.duration = duration;
                Isloop = loop;
                ResetData();
            }

            /// <summary>
            /// 重置计时器数据
            /// </summary>
            /// <param name="duration"></param>
            /// <param name="loop"></param>
            public void ResetData(string timerId, float duration, bool loop)
            {
                InitData(timerId, duration, loop);
            }

            private void ResetData()
            {
                ResetLoopData();
                onUpdate = null;
                onComplete = null;
            }

            private void ResetLoopData()
            {
                IsComplete = false;
                IsTiming = true;
                startTime = DateTime.Now;
                runTimeTotal = 0;
            }

            private bool JudgeIsComplete()
            {
                return runTimeTotal + GetCurrentTimingTime() >= duration;
            }

            private void Loop()
            {
                if (IsComplete)
                {
                    onComplete?.Invoke();
                    ResetLoopData();
                }
            }

            private void NotLoop()
            {
                if (IsComplete)
                {
                    onComplete?.Invoke();
                    onComplete = null;
                }
            }

            /// <summary>
            /// 继续执行计时器
            /// </summary>
            public void Continue()
            {
                IsTiming = true;
                startTime = DateTime.Now;
            }

            /// <summary>
            /// 暂停计时器
            /// </summary>
            public void Pause()
            {
                IsTiming = false;
                runTimeTotal += GetCurrentTimingTime();
            }

            /// <summary>
            /// 停止计时器
            /// </summary>
            public void Stop(bool isComplete)
            {
                if (IsComplete && isComplete)
                {
                    onComplete?.Invoke();
                }
                onComplete = null;
                onUpdate = null;
                runTimeTotal = 0;
                IsTiming = false;
            }

            public ITimer AddUpdateListener(Action onUpdate)
            {
                this.onUpdate += onUpdate;
                return this;
            }

            public ITimer AddCompleteListener(Action onComplete)
            {
                this.onComplete += onComplete;
                return this;
            }

            public float GetCurrentTimingTime()
            {
                var time = DateTime.Now - startTime;
                return (float)time.TotalSeconds;
            }
        }
       
        private HashSet<ITimer> activeTimer;
        private HashSet<ITimer> inactiveTimer;
        private HashSet<ITimer>.Enumerator activeEnum;
        private Dictionary<string, ITimer> timerDic;

        public TimerManager()
        {
            activeTimer = new HashSet<ITimer>();
            inactiveTimer = new HashSet<ITimer>();
            timerDic = new Dictionary<string, ITimer>();
        }

        /// <summary>
        /// 创建新计时器
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        public ITimer CreateTimer(string timerId, float duration, bool loop)
        {
            ITimer timer = null;
            if (timerDic.ContainsKey(timerId))
            {
                timer = timerDic[timerId];
                if (!timer.IsTiming)
                {
                    ResetTimer(timer, timerId, duration, loop);
                }
                else
                {
                    return null;
                }
            }
            else
            { 
                if (inactiveTimer.Count > 0)
                {
                    timer = inactiveTimer.First();

                    timerDic.Remove(timer.ID);

                    ResetTimer(timer, timerId, duration, loop);
                }
                else
                {
                    timer = new Timer(timerId, duration, loop);
                    activeTimer.Add(timer);                   
                }
                timerDic[timerId] = timer; 
            }

            timer.AddCompleteListener(() => TimerComplete(timer));
            return timer;
        }

        /// <summary>
        ///重置某个已存在的Timer数据
        /// </summary>
        /// <param name="timerId"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        public ITimer ResetTimerData(string timerId, float duration, bool loop)
        {
            if (timerDic.ContainsKey(timerId))
            {
                ITimer timer = timerDic[timerId];
                if (timer.IsTiming)
                {
                    ResetTimer(timer,timerId, duration, loop);
                }
                return timer;
            }

            return null;
        }

        private void ResetTimer(ITimer timer, string timerId, float duration, bool loop)
        {
            if (inactiveTimer.Contains(timer))
            {
                inactiveTimer.Remove(timer);
                activeTimer.Add(timer);
            }
            timer.ResetData(timerId, duration, loop);
        }

        /// <summary>
        ///重置某个已存在的Timer数据
        /// </summary>
        /// <param name="timerId"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        public ITimer ResetTimerData(TimerId timerId, float duration, bool loop)
        {
             return ResetTimerData(timerId.ToString(), duration, loop);
        }

        /// <summary>
        /// 创建计时器
        /// </summary>
        public ITimer CreateTimer(TimerId timerId,float duration,bool loop)
        {
           return  CreateTimer(timerId.ToString(), duration, loop);
        }

        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        public ITimer GetTimer(string timerId)
        {
            if(timerDic.ContainsKey(timerId))
            {
                return timerDic[timerId];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        public ITimer GetTimer(TimerId timerId)
        {
            return GetTimer(timerId.ToString());
        }

        /// <summary>
        /// 更新所有计时器
        /// </summary>
        public void Update()
        {
            activeEnum = activeTimer.GetEnumerator();
            int count = activeTimer.Count;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (!activeEnum.MoveNext())
                    {
                        continue;
                    }
                    else
                    {
                        activeEnum.Current.Update();
                    }
                }
            }
            catch (Exception)
            {

            }
           
        }

        /// <summary>
        /// 执行完毕的计时器，存入缓存
        /// </summary>
        /// <param name="timer"></param>
        public void TimerComplete(ITimer timer)
        {
            if(!timer.Isloop)
            {
                activeTimer.Remove(timer);
                inactiveTimer.Add(timer);
            }
        }

        /// <summary>
        /// 继续执行所有计时器
        /// </summary>
        public void ContinueAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Continue();
            }
        }

        /// <summary>
        /// 暂停执行所有计时器
        /// </summary>
        public void PauseAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Pause();
            }
        }

        /// <summary>
        /// 停止所有计时器
        /// </summary>
        public void StopAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Stop(false);
            }
        }

        public ITimer CreateOrRestartTimer(string timerId, float duration, bool loop)
        {
           var timer = CreateTimer(timerId, duration, loop);
            if(timer == null)
            {
                timer = ResetTimerData(timerId, duration, loop);
                timer.AddCompleteListener(() => TimerComplete(timer));
            }
            return timer;
        }

        public void StopTimer(ITimer timer, bool isComplete)
        {
            if(timer != null)
            {
                timer.Stop(isComplete);
            }
        }
    }
}
