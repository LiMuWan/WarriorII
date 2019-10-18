using System;
using System.Threading.Tasks;
using BlueGOAP;
using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class DeadView : ViewBase<ActionEnum>
    {
        public DeadView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

       

        protected void Destroy()
        {
            Transform selfTrans = _mgr.Self as Transform;
            GameObject.Destroy(selfTrans.gameObject);
        }
    }

    public  class DeadNormalView : DeadView
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD; } }

        public override string AniName
        {
            get 
            {
                if (_currentAniName == null)
                {
                    int index = UnityEngine.Random.Range(0, aniNames.Length);
                    _currentAniName = aniNames[index].ToString();
                    return _currentAniName;
                }
                else
                {
                    return _currentAniName;
                }
            }
        }

        private AIPeasantAniName[] aniNames = { AIPeasantAniName.death01, AIPeasantAniName.death02 };

        private string _currentAniName;

        public DeadNormalView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public async override void Enter()
        {
            base.Enter();
            await Task.Delay(TimeSpan.FromSeconds(_AniMgr.GetAniLength(AniName)));

            Destroy();
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
            InitSpecialDead(Path.PEASANT_DEAD_BODY_HEAD);
        }
    }

    public class DeadBodyView : DeadView
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_BODY; } }

        public override string AniName { get; }

        public DeadBodyView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            ExcuteState = BlueGOAP.ActionExcuteState.ENTER;
            InitSpecialDead(Path.PEASANT_DEAD_BODY_BODY);
        }
    }

    public class DeadLegView : DeadView
    {
        public override ActionEnum Label { get { return ActionEnum.DEAD_HALF_LEG; } }

        public override string AniName { get; }

        public DeadLegView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }

        public override void Enter()
        {
            ExcuteState = BlueGOAP.ActionExcuteState.ENTER;
            InitSpecialDead(Path.PEASANT_DEAD_BODY_LEG);
        }
    }
}
