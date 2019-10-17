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
        public AIModelMgrBase<T> ModelMgr { get; private set; }
        public EffectMgr EffectMgr { get; private set; }
        public AudioMgr AudioMgr { get; private set; }
        public AIAniMgr AniMgr { get; private set; }

        public AIViewEffectMgrBase(string enemyId, object audioSource,object animation)
        {
            _fsm = new ActionFSM<T>();
            _mutilFsm = new ActionStateFSM<T>();
            _viewDic = new Dictionary<T, IFsmState<T>>();
            _mutilActionViews = new Dictionary<T, IFsmState<T>>();
            ModelMgr = InitModelMgr();
            EffectMgr = new EffectMgr();
            AudioMgr = new AudioMgr(enemyId,audioSource);
            AniMgr = new AIAniMgr(animation);
            InitViews();
            InitMulViews();
            InitFsm();
            InitMutilFsm();
        }

        private void InitFsm()
        {
            foreach (KeyValuePair<T,IFsmState<T>> state in _viewDic)
            {
                _fsm.AddState(state.Key, state.Value);
            }
        }

        private void InitMutilFsm()
        {
            foreach (KeyValuePair<T, IFsmState<T>> state in _mutilActionViews)
            {
                _fsm.AddState(state.Key, state.Value);
            }
        }

        protected abstract void InitViews();

        protected abstract void InitMulViews();

        protected abstract AIModelMgrBase<T> InitModelMgr();

        protected void AddView(IFsmState<T> state)
        {
            T key = state.Label;

            if (_viewDic.ContainsKey(key))
            {
                DebugMsg.LogError("_viewDic已经包含当前键值 : " + key);
            }
            else
            {
                _viewDic.Add(key, state);
            }
        }

        protected void AddMutilView(IFsmState<T> state)
        {
            T key = state.Label;

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
                DebugMsg.LogWarning("动作" + key + "不在当前动作缓存中");
            }
        }
    }

    public class AIViewEffectMgr : AIViewEffectMgrBase<ActionEnum>
    {
        public AIViewEffectMgr(string enemyId , object audioSource,object animation) : base(enemyId , audioSource,animation)
        {
            
        }

        protected override void InitViews()
        {
            AddView(new AttackView(this));
            AddView(new DeadNormalView(this));
            AddView(new IdleView(this));
            AddView(new IdleSwordView(this));
            AddView(new UpInjureView(this));
            AddView(new DownInjureView(this));
            AddView(new LeftInjureView(this));
            AddView(new RightInjureView(this));
            AddView(new MoveBackwardView(this));
            AddView(new MoveView(this));
            AddView(new EnterAlertView(this));
            AddView(new ExitAlertView(this));
        }

        protected override void InitMulViews()
        {
            //AddView(new AlertStateView(this));
        }

        protected override AIModelMgrBase<ActionEnum> InitModelMgr()
        {
            return new AIModelMgr();
        }
    }
}
