﻿using BlueGOAP;
using Game.AI.Model;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class ViewBase<T> : IFsmState<T>
    {
        public ActionExcuteState ExcuteState { get; set; }
        public abstract T Label { get; }

        public abstract string AniName { get; }

        protected IModel _iModel;
        protected EffectMgr _effectMgr;
        protected AIAniMgr _AniMgr;
        protected AIViewEffectMgrBase<T> _mgr;

        public ViewBase(AIViewEffectMgrBase<T> mgr)
        {
            _AniMgr = mgr.AniMgr;
            _effectMgr = mgr.EffectMgr;
            _iModel = InitModel(mgr);
            _mgr = mgr;
        }

        private IModel InitModel(AIViewEffectMgrBase<T> mgr)
        {
            IModel model = mgr.ModelMgr.GetModel<IModel>(Label);
            if(model != null)
            {
                model.AniDuration = _AniMgr.GetAniLength(AniName);
            }
            return model;
        }

        public virtual void Enter()
        {
            ExcuteState = ActionExcuteState.ENTER;
            _AniMgr.Play(AniName);
        }

        public virtual void Execute()
        {
            ExcuteState = ActionExcuteState.EXCUTE;
        }

        public virtual void Exit()
        {
            ExcuteState = ActionExcuteState.EXIT;
        }
    }
}

