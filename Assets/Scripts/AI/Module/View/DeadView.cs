﻿using BlueGOAP;
using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class DeadView : ViewBase<ActionEnum>
    {
        public DeadView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

    public  class DeadNormalView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }

        public override string AniName
        {
            get 
            {
                int index = Random.Range(0, aniNames.Length);
                return aniNames[index].ToString();
            }
        }

        private AIPeasantAniName[] aniNames = { AIPeasantAniName.death01, AIPeasantAniName.death02 };

        public DeadNormalView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

    public class DeadHeadView : DeadView
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_HEAD; } }

        public override string AniName { get; }

        public DeadHeadView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            ExcuteState = BlueGOAP.ActionExcuteState.ENTER;
            GameObject dead = LoadManager.Single.Load<GameObject>(Path.PEASANT_DEAD_BODY_HEAD, "");
            if (dead != null)
            {
                DeadAniController aniCtrl = dead.AddComponent<DeadAniController>();
                Transform selfTrans = _mgr.Self as Transform;
                aniCtrl.Init(selfTrans.position);

                GameObject.Destroy(selfTrans.gameObject);
            }
            else
            {
                DebugMsg.LogError("死亡动画未找到，标签为 : " + Label);
            }
        }
    }

}
