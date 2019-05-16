using UnityEngine;

namespace UIFrame
{
    //显示在整个界面的UI
    public abstract class BasicUI : UIBase   
    {
        protected override void Init()
        {
            Layer = Const.UILayer.BASIC_UI;
        }
    }
}
