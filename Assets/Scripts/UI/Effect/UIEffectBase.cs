using Const;
using System;
using UnityEngine;
using Util;

namespace UIFrame
{
    public abstract class UIEffectBase : MonoBehaviour    
    {

        /*����д��Ŀ���ǣ�Ϊ�˱����ⲿ��֪��������ʹ�öಥ
         * �������Ͻ�ʹ�öಥ�ģ�ÿ��ִֻ��һ������������һһ��Ӧ�Ĺ�ϵ
         * Ϊ�˱����¼��ܶ����û�жಥ����ͼ������д
         */
        protected Vector2 defaultAnchorPos = new Vector2(0, 0); 
        
        protected Action onEnterComplete;

        protected Action onExitComplete;
        public virtual void Enter()
        {
            if(defaultAnchorPos == Vector2.zero)
            {
                defaultAnchorPos = transform.RectTransform().anchoredPosition;
            }
        }
        public abstract void Exit();

        public void OnEnterComplete(Action onEnterAction)
        {
            this.onEnterComplete= onEnterAction;
        }
        public void OnExitComplete(Action onExitAction)
        {
            this.onExitComplete = onExitAction;
        }

        public abstract UiEffect GetUIEffectLevel();
    }
}
