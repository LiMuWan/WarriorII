using Const;
using UnityEngine;

namespace UIFrame
{
    //显示在整个界面的UI
    public abstract class BasicUI : UIBase   
    {
        public override UILayer GetUILayer()
        {
            return UILayer.BASIC_UI;
        }
    }
}
