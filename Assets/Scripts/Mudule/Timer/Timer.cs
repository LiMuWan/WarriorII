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
        /// Ψһ��ʶ
        /// </summary>
        string ID { get; }
        /// <summary>
        /// ��ǰ��ʱ��
        /// </summary>
        float CurrentTime { get; }
        /// <summary>
        /// ���аٷֱ�
        /// </summary>
        float Percent { get; }
        /// <summary>
        /// ����ѭ������ʱ�� 
        /// </summary>
        float Duration { get; }
        /// <summary>
        /// �Ƿ�ѭ��
        /// </summary>
        bool Isloop { get; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// ֡����
        /// </summary>
        void Update();
        /// <summary>
        /// ������ʱ
        /// </summary>
        void Continue();
        /// <summary>
        /// ��ͣ��ʱ
        /// </summary>
        void Pause();
        /// <summary>
        /// ֹͣ��ʱ
        /// </summary>
        void Stop();
        /// <summary>
        /// ��������
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
        /// ������ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(string id,float duration, bool loop);

        /// <summary>
        /// ������ʱ��
        /// </summary>
        ITimer CreateTimer(TimerId timerId, float duration, bool loop);

        /// <summary>
        /// ����id��ȡ��ʱ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ITimer GetTimer(string id);

        /// <summary>
        /// ����id��ȡ��ʱ��
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        ITimer GetTimer(TimerId timerId);
        /// <summary>
        /// ֡����
        /// </summary>
        void Update();

        /// <summary>
        /// ����ִ�����м�ʱ��
        /// </summary>
        void ContinueAll();

        /// <summary>
        /// ��ͣ���м�ʱ��
        /// </summary>
        void PauseAll();

        /// <summary>
        /// �ر����м�ʱ��
        /// </summary>
        void StopAll();
    }

    public class TimerManager:ITimeManager
    {
        /// <summary>
        /// ��ʱ��
        /// </summary>
        private class Timer : ITimer
        {
            /// <summary>
            /// Ψһ��ʶ
            /// </summary>
            public string ID { get; private set; }
            /// <summary>
            /// ��ǰ��ʱ��
            /// </summary>
            public float CurrentTime { get { return runTimeTotal; } }
            /// <summary>
            /// ���аٷֱ�
            /// </summary>
            public float Percent { get { return runTimeTotal / duration; } }
            /// <summary>
            /// ����ѭ������ʱ�� 
            /// </summary>
            public float Duration { get { return duration; } }
            //�Ƿ�ѭ��ִ��
            public bool Isloop { get; private set; }

            //�Ƿ����
            public bool IsComplete { get; private set; }

            private Action onUpdate;
            private Action onComplete;

            //�Ƿ����ڼ�ʱ
            private bool isTiming;
          
            //��ʱ��ʼʱ��
            private DateTime startTime;
            //������ʱ��
            private float runTimeTotal;
          
            //����ʱ�� 
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
            /// ����ʱ�䵥λΪ��
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
            /// ���ü�ʱ������
            /// </summary>
            /// <param name="duration"></param>
            /// <param name="loop"></param>
            public void ResetData(string id,float duration, bool loop)
            {
                InitData(id,duration, loop);
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
            /// ����ִ�м�ʱ��
            /// </summary>
            public void Continue()
            {
                isTiming = true;
                startTime = DateTime.Now;
            }

            /// <summary>
            /// ��ͣ��ʱ��
            /// </summary>
            public void Pause()
            {
                isTiming = false;
                runTimeTotal += GetCurrentTimingTime();
            }

            /// <summary>
            /// ֹͣ��ʱ��
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
        /// �����¼�ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        public ITimer CreateTimer(string id,float duration, bool loop)
        {
            if (timerDic.ContainsKey(id))
            {
                Debug.LogError("id:" + id + "�Ѵ��ڣ�");
                return null;
            }
            else
            {
                ITimer timer = null;
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
                    timer.AddCompleteListener(() => TimerComplete(timer));
                }
                timerDic[id] = timer; 
                return timer;
            }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        public ITimer CreateTimer(TimerId timerId,float duration,bool loop)
        {
           return  CreateTimer(timerId.ToString(), duration, loop);
        }

        /// <summary>
        /// ����id��ȡ��ʱ��
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
        /// ����id��ȡ��ʱ��
        /// </summary>
        /// <param name="timerId"></param>
        /// <returns></returns>
        public ITimer GetTimer(TimerId timerId)
        {
            return GetTimer(timerId.ToString());
        }

        /// <summary>
        /// �������м�ʱ��
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
        /// ִ����ϵļ�ʱ�������뻺��
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
        /// ����ִ�����м�ʱ��
        /// </summary>
        public void ContinueAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Continue();
            }
        }

        /// <summary>
        /// ��ִͣ�����м�ʱ��
        /// </summary>
        public void PauseAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Pause();
            }
        }

        /// <summary>
        /// ֹͣ���м�ʱ��
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
