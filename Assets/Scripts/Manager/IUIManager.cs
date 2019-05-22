using Const;
using UnityEngine;

namespace UIFrame
{
    public interface IUIManager    
    {
        void Show(UiId uiId);

        void Hide();

        void Back();

    }
}
