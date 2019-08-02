using Const;
using Game.Interface;
using Manager;
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

        public void Attack(int skillCode)
        {
            Play(AudioName.attack);
        }
    }
}
