using UnityEngine;
using System.Collections.Generic;
using Const;
using Util;
using System;

namespace Manager
{
    public class LoadAudioManager:SingletonBase<LoadAudioManager>
    {
        /// <summary>
        /// 玩家音效缓存
        /// </summary>
        private Dictionary<string, AudioClip> _playerAudioDic;
        //第一层key是EnemyID枚举值，value值是当前怪物对应的音效字典
        private Dictionary<string, Dictionary<string, AudioClip>> _enemyClipsDic;

        public void Init()
        {
            _playerAudioDic = new Dictionary<string, AudioClip>();
            LoadAllAudio(Const.Path.AUDIO_PLAYER_PATH, _playerAudioDic);
            _enemyClipsDic = new Dictionary<string, Dictionary<string, AudioClip>>();
            foreach (EnemyId id in Enum.GetValues(typeof(EnemyId)))
            {
                _enemyClipsDic[id.ToString()] = new Dictionary<string, AudioClip>();
                LoadAllAudio(Const.Path.AUDIO_PATH + id.ToString() + "/", _enemyClipsDic[id.ToString()]);
            }
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
            if(_playerAudioDic.ContainsKey(name))
            {
                return _playerAudioDic[name];
            }
            else
            {
                Debug.LogErrorFormat("人物音效中未发现名为{0}的AudioClip",name);
                return null;
            }
        }

        public AudioClip EnemyAudio(string enemyId,string name)
        {
            if (_enemyClipsDic[enemyId].ContainsKey(name))
            {
                return _enemyClipsDic[enemyId][name];
            }
            else
            {
                Debug.LogErrorFormat("Enemy音效中未发现名为{0}的AudioClip", name);
                return null;
            }
        }
    }
}
