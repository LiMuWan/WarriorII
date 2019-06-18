using UnityEngine;

namespace Const
{
   public enum UILayer
   {
     BASIC_UI,//��ʾ�������������UI
     OVERLAY_UI,//��UI,����
     TOP_UI,// �ö�����
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
    /// ����������Ӧö��
    /// </summary>
    public enum PlayerAniIndex
    {
        IDLE,
        RUN,
        WALK
    }

    /// <summary>
    /// ��ʱ��id
    /// </summary>
    public enum TimerId
    {
        MOVE_TIMER,
    }
}
