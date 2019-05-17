using Const;
using System;
using UnityEngine;

namespace UIFrame
{
    public abstract class UIEffectBase : MonoBehaviour    
    {

        /*这样写的目的是，为了避免外部不知情的情况下使用多播
         * 这里是严禁使用多播的，每个只执行一个方法，它是一一对应的关系
         * 为了避免事件很多错误，没有多播的意图就这样写
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
