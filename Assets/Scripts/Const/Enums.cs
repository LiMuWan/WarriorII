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
    }

    public enum UiEffect
    {
        VIEW_EFFECT,
        OTHER_EFFECT,
    }
}
