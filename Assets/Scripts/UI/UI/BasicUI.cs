using Const;
using UnityEngine;

namespace UIFrame
{
    //��ʾ�����������UI
    public abstract class BasicUI : UIBase   
    {
        public override UILayer GetUILayer()
        {
            return UILayer.BASIC_UI;
        }
    }
}
