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
        void ResetData(float duration, bool loop);

        void AddUpdateListener(Action onUpdate);
        void AddCompleteListener(Action onComplete);
    }
   
    public interface ITimeManager
    {
        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(float duration, bool loop);
        /// <summary>
        /// ֡����
        /// </summary>
        void Update();
        //����ִ�����м�ʱ��
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

    public class TimerManager
    {
        /// <summary>
        /// ��ʱ��
        /// </summary>
        private class Timer : ITimer
        {
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
            public bool IsComplete
            {
                get
                {
                    return runTimeTotal >= duration;
                }
            }

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
            public void Update()
            {
                if (!IsComplete || !isTiming)
                    return;
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
                }
            }

            public void Continue()
            {
                isTiming = true;
                startTime = DateTime.Now;
            }
            public void Pause()
            {
                isTiming = false;
                runTimeTotal += GetCurrentTimingTime();
            }

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

        public TimerManager()
        {
            activeTimer = new HashSet<ITimer>();
            inactiveTimer = new HashSet<ITimer>();
        }

        /// <summary>
        /// �����¼�ʱ��
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
            }
            return timer;
        }

        public void Update()
        {
            if(activeTimer.Count > 0)
            {
                foreach (var timer in activeTimer)
                {
                    timer.Update();
                    SetInactiveTimer(timer);
                }
            }
        }

        /// <summary>
        /// ִ����ϵļ�ʱ�������뻺��
        /// </summary>
        /// <param name="timer"></param>
        public void SetInactiveTimer(ITimer timer)
        {
            if(!timer.Isloop && timer.IsComplete)
            {
                activeTimer.Remove(timer);
                inactiveTimer.Add(timer);
            }
        }

        public void ContinueAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Continue();
            }
        }

        public void PauseAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Pause();
            }
        }

        public void StopAll()
        {
            foreach (ITimer timer in activeTimer)
            {
                timer.Stop();
            }
        }
    }
}
