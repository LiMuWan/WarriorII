using UnityEngine;

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
    /// 动画参数对应枚举
    /// </summary>
    public enum PlayerAniIndex
    {
        IDLE,
        RUN,
        WALK
    }

    /// <summary>
    /// 计时器id
    /// </summary>
    public enum TimerId
    {
        MOVE_TIMER,
    }
}
