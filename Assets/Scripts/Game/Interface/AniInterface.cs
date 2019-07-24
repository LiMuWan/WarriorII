﻿using UnityEngine;

namespace Game.Interface
{
    /// <summary>
    /// 动画部分接口
    /// </summary>
    public interface IAni
    {
        void Play(int aniIndex);

        ICustomAniEventManager AniEventManager { get; set; }
    }

    public interface IPlayerAni:IAni,IPlayerBehaviour
    {

    }
}
