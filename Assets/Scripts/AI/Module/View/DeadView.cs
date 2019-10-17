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

}
