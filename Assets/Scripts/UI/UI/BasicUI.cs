using UnityEngine;

namespace UIFrame
{
    //��ʾ�����������UI
    public abstract class BasicUI : UIBase   
    {
        protected override void Init()
        {
            Layer = Const.UILayer.BASIC_UI;
        }
    }
}
