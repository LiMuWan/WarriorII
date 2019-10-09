using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AudioMgr     
    {
        public void Play<T>(T audioName)
        {
            AudioClip clip = GetAudioClip(audioName.ToString());
            if (clip == null)
                return;
        }

        private AudioClip GetAudioClip(string name)
        {
            return LoadAudioManager.Single.EnemyAudio(name);
        }
    }
}
