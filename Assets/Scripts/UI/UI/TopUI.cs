using Const;
using UnityEngine;

namespace UIFrame
{
    public abstract class TopUI : UIBase   
    {
        public override UILayer GetUILayer()
        {
            return UILayer.TOP_UI;
        }

    }
}
