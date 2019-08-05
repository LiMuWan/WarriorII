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
        public bool IsRun { get; set; }

        public bool IsAttack { get; private set; }

        private AudioSource audioSource;

        public PlayerAudio(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }

        public void Play(string name)
        {
            audioSource.PlayOneShot(GetAudioClip(name));
        }

        public void Play(AudioName audioName)
        {
            Play(audioName.ToString());
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
            Play(AudioName.step);
        }

        public async void Attack(int skillCode)
        {
            await Task.Delay(TimeSpan.FromSeconds(Const.ConstValue.SKILL_START_TIME));
            Play(AudioName.attack);
        }
    }
}
