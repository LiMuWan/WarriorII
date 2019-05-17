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
    }

    public enum UiEffect
    {
        VIEW_EFFECT,
        OTHER_EFFECT,
    }
}
