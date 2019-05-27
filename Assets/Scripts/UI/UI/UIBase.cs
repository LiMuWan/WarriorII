using Const;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public abstract class UIBase : MonoBehaviour    
    {
        public UILayer Layer { get; protected set;}

        private UIState uiState;

        public UIState UIState
        {
            get { return uiState; }
            set { HandleState(value); }
        }

        public void HandleState(UIState value)
        {
            switch (value)
            {
                case UIState.INIT:
                    if(uiState == UIState.NORMAL)
                    {
                        Init();
                    }
                    break;
                case UIState.SHOW:
                    if(UIState == UIState.NORMAL)
                    {
                        Init();
                        Show();
                    }
                    break;
                case UIState.HIDE:
                    Hide();
                    break;
            }
        }
        protected virtual void Init()
        {
            
        }       

        protected virtual void Normal()
        {
            
        }

        protected virtual void Show()
        {
            //SetActive(true);
        }

        protected virtual void Hide()
        {
           // SetActive(false);
        }

        public void SetActive(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        public abstract UiId GetUiId();

        public abstract List<Transform> GetBtnParents();
    }
}
