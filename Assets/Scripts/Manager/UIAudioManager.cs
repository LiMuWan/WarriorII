using System;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class UIAudioManager : MonoBehaviour    
    {
        private AudioSource audioSource;
        private Func<string, AudioClip[]> LoadAudioSourceFunc;
        private readonly Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();
        public void Awake()        
        {
            audioSource = transform.GetOrAddComponent<AudioSource>();
        }

        public void Init(string audioPath,Func<string,AudioClip[]> loadFunc)
        {
            AddLoadAudioSourceFunc(loadFunc);
            LoadAllAudioClip(audioPath);
        }

        public void AddLoadAudioSourceFunc(Func<string,AudioClip[]> loadFunc)
        {
            if(loadFunc == null)
            {
                Debug.LogError("loadAudioSourceFunc can not be null !");
                return;
            }
            this.LoadAudioSourceFunc = loadFunc;
        }

        private void LoadAllAudioClip(string audioPath)
        {
            var audios = LoadAudioSourceFunc(audioPath);
            foreach (AudioClip clip in audios)
            {
                if(!audioClipDic.ContainsKey(clip.name))
                {
                    audioClipDic[clip.name] = clip;
                }
            }
        }

        private AudioClip GetAudioClip(string clipName)
        {
            if(audioClipDic.ContainsKey(clipName))
            {
                return audioClipDic[clipName];
            }
            else
            {
                Debug.LogError("audioClipDic don't contains the clipName : " + clipName);
                return null;
            }
        }

        public void Play(string clipName)
        {
            var clip = GetAudioClip(clipName);
            if(clip != null)
            {
                audioSource.clip = clip;
            }
        }
    }
}
