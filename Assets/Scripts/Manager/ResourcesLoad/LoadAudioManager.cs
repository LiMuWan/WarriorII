using UnityEngine;
using System.Collections.Generic;
using Const;
using Util;

namespace Manager
{
    public class LoadAudioManager:SingletonBase<LoadAudioManager>
    {
        /// <summary>
        /// 玩家音效缓存
        /// </summary>
        private Dictionary<string, AudioClip> playerAudioDic;

        public void Init()
        {
            playerAudioDic = new Dictionary<string, AudioClip>();
            LoadAllAudio(Const.Path.AUDIO_PLAYER_PATH, playerAudioDic);
        }

        private void LoadAllAudio(string path,Dictionary<string,AudioClip> audioDic)
        {
            var audioClips = LoadManager.Single.LoadAll<AudioClip>(path);
            foreach (AudioClip  clip in audioClips)
            {
                audioDic[clip.name] = clip;
            }
        }

        public AudioClip PlayerAudio(string name)
        {
            if(playerAudioDic.ContainsKey(name))
            {
                return playerAudioDic[name];
            }
            else
            {
                Debug.LogErrorFormat("人物音效中未发现名为{0}的AudioClip",name);
                return null;
            }
        }

        public AudioClip EnemyAudio(string name)
        {
            if (playerAudioDic.ContainsKey(name))
            {
                return playerAudioDic[name];
            }
            else
            {
                Debug.LogErrorFormat("Enemy音效中未发现名为{0}的AudioClip", name);
                return null;
            }
        }
    }
}
