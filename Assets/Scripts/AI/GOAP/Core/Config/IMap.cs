using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IMap<TAction>
    {
        IActionHandler<TAction> GetActionHandler(TAction actionLabel);
    }

    public abstract class MapBase<TAction> : IMap<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;

        public MapBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
        }

        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            IActionHandler<TAction> handler = null;
            _actionHandlerDic.TryGetValue(actionLabel, out handler);

            if (handler == null)
                DebugMsg.LogError("当前映射中未找到对应IActionHandler,标签名称为：" + actionLabel);

            return handler;
        }
    }
}
