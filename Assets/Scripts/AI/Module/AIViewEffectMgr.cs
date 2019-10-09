using System.Collections.Generic;
using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class AIViewEffectMgrBase<T>   
    {
        private IFSM<T> _fsm;
        private IFSM<T> _mutilFsm;
        private Dictionary<T, IFsmState<T>> _viewDic;
        private Dictionary<T, IFsmState<T>> _mutilActionViews;

        public AIViewEffectMgrBase()
        {
            _fsm = new ActionFSM<T>();
            _mutilFsm = new ActionStateFSM<T>();
            _viewDic = new Dictionary<T, IFsmState<T>>();
            _mutilActionViews = new Dictionary<T, IFsmState<T>>();
            InitViews();
            InitMulViews();
        }

        protected abstract void InitViews();

        protected abstract void InitMulViews();

        protected void AddView(T key,IFsmState<T> state)
        {
            if(_viewDic.ContainsKey(key))
            {
                DebugMsg.LogError("_viewDic已经包含当前键值 : " + key);
            }
            else
            {
                _viewDic.Add(key, state);
            }
        }

        protected void AddMutilView(T key,IFsmState<T> state)
        {
            if (_mutilActionViews.ContainsKey(key))
            {
                DebugMsg.LogError("_mutilActionViews已经包含当前键值 : " + key);
            }
            else
            {
                _mutilActionViews.Add(key, state);
            }
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

    public class AIViewEffectMgr : AIViewEffectMgrBase<ActionEnum>
    {
        public AIViewEffectMgr() : base()
        {
            
        }

        protected override void InitViews()
        {
            AddView(ActionEnum.ATTACK, new AttackView());
        }

        protected override void InitMulViews()
        {
            throw new System.NotImplementedException();
        }

    }
}
