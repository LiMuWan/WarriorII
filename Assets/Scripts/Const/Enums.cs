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
}
