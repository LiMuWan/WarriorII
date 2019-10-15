namespace Game.AI.ViewEffect
{
    public class UpInjureView : InjureView
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_UP; } }
        public override string AniName { get { return AIPeasantAniName.injuryFront03.ToString(); } }

        public UpInjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {
        }
    }

    public class DownInjureView : InjureView
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_DOWN; } }
        public override string AniName { get { return AIPeasantAniName.injuryFront04.ToString(); } }

        public DownInjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

    public class LeftInjureView : InjureView
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_LEFT; } }
        public override string AniName { get { return AIPeasantAniName.injuryFront01.ToString(); } }

        public LeftInjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }

    public class RightInjureView : InjureView
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE_RIGHT; } }
        public override string AniName { get { return AIPeasantAniName.injuryFront02.ToString(); } }

        public RightInjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
