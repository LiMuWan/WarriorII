using System.Collections.Generic;
using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AIViewEffectMgr<T>   
    {
        private IFSM<T> _fsm;
        private IFSM<T> _mutilFsm;
        private Dictionary<T, IActionHandler<T>> _viewDic;
        private Dictionary<T, IActionHandler<T>> _mutilActionViews;

        public AIViewEffectMgr()
        {
            _fsm = new ActionFSM<T>();
            _mutilFsm = new ActionStateFSM<T>();
        }

        public void ExecuteState(T key)
        {
            if (_viewDic.ContainsKey(key))
            {
                _fsm.ExcuteNewState(key);
            }
            else if (_mutilActionViews.ContainsKey(key))
            {
                _mutilFsm.ExcuteNewState(key);
            }
            else
            {
                DebugMsg.LogError("动作" + key + "不在当前动作缓存中");
            }
        }
    }
}
