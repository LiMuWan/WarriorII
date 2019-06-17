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
        void Stop();
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(float duration, bool loop);

        void AddUpdateListener(Action onUpdate);
        void AddCompleteListener(Action onComplete);
    }
   
    public interface ITimeManager
    {
        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(float duration, bool loop);
        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();
        //继续执行所有计时器
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
            private bool isTiming;
          
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
                if (IsComplete || !isTiming)
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
            public Timer(float duration, bool loop)
            {
                InitData(duration, loop);
            }

            private void InitData(float duration, bool loop)
            {
                this.duration = duration;
                Isloop = loop;
                ResetData();
            }

            /// <summary>
            /// 重置计时器数据
            /// </summary>
            /// <param name="duration"></param>
            /// <param name="loop"></param>
            public void ResetData(float duration, bool loop)
            {
                InitData(duration, loop);
            }

            private void ResetData()
            {
                isTiming = true;
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
                    IsComplete = false;
                    onComplete?.Invoke();
                    ResetData();
                }
            }

            private void NotLoop()
            {
                if (IsComplete)
                {
                    onComplete?.Invoke();
                }
            }

            /// <summary>
            /// 继续执行计时器
            /// </summary>
            public void Continue()
            {
                isTiming = true;
                startTime = DateTime.Now;
            }

            /// <summary>
            /// 暂停计时器
            /// </summary>
            public void Pause()
            {
                isTiming = false;
                runTimeTotal += GetCurrentTimingTime();
            }

            /// <summary>
            /// 停止计时器
            /// </summary>
            public void Stop()
            {
                if (IsComplete)
                {
                    onComplete?.Invoke();
                }
                runTimeTotal = 0;
                isTiming = false;
            }

            public void AddUpdateListener(Action onUpdate)
            {
                this.onUpdate += onUpdate;
            }

            public void AddCompleteListener(Action onComplete)
            {
                this.onComplete += onComplete;
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
        public TimerManager()
        {
            activeTimer = new HashSet<ITimer>();
            inactiveTimer = new HashSet<ITimer>();
        }

        /// <summary>
        /// 创建新计时器
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        public ITimer CreateTimer(float duration, bool loop)
        {
            ITimer timer = null;
            if (inactiveTimer.Count > 0)
            {
                timer = inactiveTimer.First();
                inactiveTimer.Remove(timer);
                timer.ResetData(duration, loop);
                activeTimer.Add(timer);
            }
            else
            {
                timer = new Timer(duration, loop);
                activeTimer.Add(timer);
                timer.AddCompleteListener(() => TimerComplete(timer));
            }
            return timer;
        }

        /// <summary>
        /// 更新所有计时器
        /// </summary>
        public void Update()
        {
            activeEnum = activeTimer.GetEnumerator();
            int count = activeTimer.Count;
            for (int i = 0; i < count; i++)
            {
                if(!activeEnum.MoveNext())
                {
                    continue;
                }
                else
                {
                    activeEnum.Current.Update();
                }
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
                timer.Stop();
            }
        }
    }
}
