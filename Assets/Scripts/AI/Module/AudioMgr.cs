using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AudioMgr     
    {
        private AudioSource _audioSource;
        private string _EnemyId;
        public AudioMgr(string enemyId, object audioSource)
        {
            _audioSource = audioSource as AudioSource;
            _EnemyId = enemyId;
        }

        public void Play<T>(T audioName,float volume)
        {
            AudioClip clip = GetAudioClip(_EnemyId,audioName.ToString());
            if (clip == null)
                return;
            _audioSource.PlayOneShot(clip,volume);
        }

        private AudioClip GetAudioClip(string enemyId,string name)
        {
            return LoadAudioManager.Single.EnemyAudio(enemyId,name);
        }
    }
}
