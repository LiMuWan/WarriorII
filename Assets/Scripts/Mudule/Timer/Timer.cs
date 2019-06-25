using Const;
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
        void Stop();
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(string id,float duration, bool loop);

        ITimer AddUpdateListener(Action onUpdate);
        ITimer AddCompleteListener(Action onComplete);
    }
   
    public interface ITimeManager
    {
        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(string id,float duration, bool loop);

        /// <summary>
        /// 创建计时器
        /// </summary>
        ITimer CreateTimer(TimerId timerId, float duration, bool loop);

        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ITimer GetTimer(string id);

        /// <summary>
        /// 根据id获取计时器
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        ITimer GetTimer(TimerId timerId);
        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();

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
            public Timer(string id,float duration, bool loop)
            {
                InitData(id,duration, loop);
            }

            private void InitData(string id,float duration, bool loop)
            {
                this.ID = id;
                this.duration = duration;
                Isloop = loop;
                ResetData();
            }

            /// <summary>
            /// 重置计时器数据
            /// </summary>
            /// <param name="duration"></param>
            /// <param name="loop"></param>
            public void ResetData(string id,float duration, bool loop)
            {
                InitData(id,duration, loop);
            }

            private void ResetData()
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
                    ResetData();
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
            public void Stop()
            {
                if (IsComplete)
                {
                    onComplete?.Invoke();
                }
                onComplete = null;
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
        public ITimer CreateTimer(string id,float duration, bool loop)
        {
            ITimer timer = null;
            if (timerDic.ContainsKey(id))
            {
                timer = timerDic[id];
                if (!timer.IsTiming)
                {
                    inactiveTimer.Remove(timer);
                    timer.ResetData(id, duration, loop);
                    activeTimer.Add(timer);
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

                    inactiveTimer.Remove(timer);
                    timer.ResetData(id, duration, loop);
                    activeTimer.Add(timer);
                }
                else
                {
                    timer = new Timer(id, duration, loop);
                    activeTimer.Add(timer);                   
                }
                timer.AddCompleteListener(() => TimerComplete(timer));
                timerDic[id] = timer; 
            }
            return timer;
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
        /// <param name="id"></param>
        /// <returns></returns>
        public ITimer GetTimer(string id)
        {
            if(timerDic.ContainsKey(id))
            {
                return timerDic[id];
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
