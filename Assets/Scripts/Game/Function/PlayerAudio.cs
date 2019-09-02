using Const;
using Game.Interface;
using Manager;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class PlayerAudio : IPlayerAudio
    {
        private int times;
        private bool isRun;
        public bool IsRun {
            get{ return isRun; }
            set
            {
                times = 0;
                isRun = value;
            }
        }

        public bool IsAttack { get; private set; }

        public bool IsColliderWall { get; set; }

        private AudioSource audioSource;

        public PlayerAudio(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }

        public void Play(string name,float volume)
        {
            audioSource.PlayOneShot(GetAudioClip(name),volume);
        }

        public void Play(AudioName audioName)
        {
            Play(audioName.ToString(),0.4f);
        }

        private AudioClip GetAudioClip(string name)
        {
            return LoadAudioManager.Single.PlayerAudio(name);
        }

        public void Idle()
        {
            
        }

        public void TurnBack()
        {
            
        }

        public void TurnForward()
        {
            
        }

        public void TurnLeft()
        {
            
        }

        public void TurnRight()
        {
          
        }

        public void Move()
        {
            if (times == 0)
            {
                Play(AudioName.step);
            }
            times++;
            if (times >= GetFrames())
            {
                times = 0;
            }
        }

        private int GetFrames()
        {
            if(IsRun)
            {
                return Const.ConstValue.RUN_STEP_TIME;
            }
            else
            {
                return Const.ConstValue.WALK_STEP_TIME;
            }
        }

        public async void Attack(int skillCode)
        {
            await Task.Delay(TimeSpan.FromSeconds(Const.ConstValue.SKILL_START_TIME));
            Play(AudioName.attack);
        }
    }
}
