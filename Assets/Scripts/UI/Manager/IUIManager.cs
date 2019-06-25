using Const;
using UnityEngine;

namespace Manager
{
    public interface IUIManager    
    {
        void Show(UiId uiId);

        void Hide();

        void Back();

    }
}
