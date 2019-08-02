using Game.Interface;
using UnityEngine;

namespace Game
{
    public class PlayerAudio : IPlayerAudio
    {
        public bool IsRun { get; set; }

        public bool IsAttack { get; private set; }

        public PlayerAudio(AudioSource audioSource)
        {

        }

        public void Play(string name)
        {
            
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
            
        }

        public void Attack(int skillCode)
        {
            
        }
    }
}
