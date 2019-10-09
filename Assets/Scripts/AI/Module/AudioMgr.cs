using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AudioMgr     
    {
        private AudioSource _audioSource;

        public AudioMgr(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void Play<T>(T audioName,float volume)
        {
            AudioClip clip = GetAudioClip(audioName.ToString());
            if (clip == null)
                return;
            _audioSource.PlayOneShot(clip,volume);
        }

        private AudioClip GetAudioClip(string name)
        {
            return LoadAudioManager.Single.EnemyAudio(name);
        }
    }
}
