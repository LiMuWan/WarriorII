using Const;
using System;
using UnityEngine;

namespace UIFrame
{
    public abstract class UIEffectBase : MonoBehaviour    
    {

        /*����д��Ŀ���ǣ�Ϊ�˱����ⲿ��֪��������ʹ�öಥ
         * �������Ͻ�ʹ�öಥ�ģ�ÿ��ִֻ��һ������������һһ��Ӧ�Ĺ�ϵ
         * Ϊ�˱����¼��ܶ����û�жಥ����ͼ������д
         */
        protected Action onEnterComplete;

        protected Action onExitComplete;
        public abstract void Enter();
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
