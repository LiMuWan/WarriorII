﻿using UnityEngine;

namespace Const
{
   public enum UILayer
   {
     BASIC_UI,//显示在整个界面的主UI
     OVERLAY_UI,//子UI,弹窗
     TOP_UI,// 置顶界面
   }

   public enum UIState
   {
        NORMAL,
        INIT,
        SHOW,
        HIDE,
   }

    public enum UiId
    {
        MainMenu,
        StartGame,
        NewGameWarning,
        Loading,
    }

    public enum UiEffect
    {
        VIEW_EFFECT,
        OTHER_EFFECT,
    }

    public enum SelectedState
    {
        SELECTED,
        UNSELECTED,
    }

    public enum UIAudioName
    {
        UI_bg,
        UI_click,
        UI_in,
        UI_logo_in,
        UI_logo_out,
        UI_out,
    }

    public enum BGAudioName
    {
        Level_Bg
    }

    public enum DifficultLevel
    {
        None,
        Easy,
        Normal,
        Hard,
    }

    public enum ComicsParentId
    {
        LeftComics,
        CurrentComics,
        RightComics
    }

    /// <summary>
    /// 游戏UI预制名字
    /// </summary>
    public enum GameUIName
    {
        HumanSkill
    }


    /// <summary>
    /// 动画参数对应枚举
    /// </summary>
    public enum PlayerAniIndex
    {
        IDLE,
        RUN,
        WALK
    }

    /// <summary>
    /// 人物行为对应枚举
    /// </summary>
    public enum PlayerBehaviourIndex
    {
        IDLE,
        RUN,
        WALK,
        ATTACK
    }

    /// <summary>
    /// 状态机行为状态
    /// </summary>
    public enum BehaviourState
    {
        ENTER,
        UPDATE,
        EXIT
    }

    /// <summary>
    /// 计时器id
    /// </summary>
    public enum TimerId
    {
        MOVE_TIMER,
        /// <summary>
        /// 判断角色技能是否在有效时间内
        /// </summary>
        HUMAN_SKILL_TIMER,
    }

    /// <summary>
    /// 音效部分统一名称
    /// </summary>
    public enum AudioName
    {
        attack,
        hard,
        injory,
        kotoul,
        step,
    }

    public enum EnemyId
    {
        /// <summary>
        /// 弓箭手
        /// </summary>
        EnemyBowman,
        /// <summary>
        /// 近战小怪
        /// </summary>
        EnemyPeasant,
        /// <summary>
        /// 近战精英怪
        /// </summary>
        EnemySwordsman,
        /// <summary>
        /// Boss
        /// </summary>
        EnemyMiniBoss
    }
}
