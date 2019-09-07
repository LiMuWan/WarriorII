using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IMap<TAction,TGoal>
    {
        IActionHandler<TAction> GetActionHandler(TAction actionLabel);
    }

    public abstract class MapBase<TAction,TGoal> : IMap<TAction, TGoal>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;

        public MapBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            InitActionMap();
        }

        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            IActionHandler<TAction> handler = null;
            _actionHandlerDic.TryGetValue(actionLabel, out handler);

            if (handler == null)
                DebugMsg.LogError("当前映射中未找到对应IActionHandler,标签名称为：" + actionLabel);

            return handler;
        }

        protected abstract void InitActionMap();

        protected void AddAction(IActionHandler<TAction> handler)
        {
            if(!_actionHandlerDic.ContainsKey(handler.Label))
            {
                _actionHandlerDic.Add(handler.Label, handler);
            }
            else
            {
                DebugMsg.LogError("发现具有重复标签的Handler，标签为：" + handler.Label);
            }
        }
    }
}
