using Const;
using UnityEngine;

namespace UIFrame
{
    public abstract class OverlayUI : UIBase
    {
        public override UILayer GetUILayer()
        {
            return UILayer.OVERLAY_UI;
        }
    }
}
