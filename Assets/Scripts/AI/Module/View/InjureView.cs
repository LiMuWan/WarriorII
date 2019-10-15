using UnityEngine;

namespace Game.AI.ViewEffect
{
    /// <summary>
    /// 防止外部new这个类
    /// </summary>
    public abstract class InjureView : ViewBase<ActionEnum>
    {
        public override ActionEnum Label { get; }

        public override string AniName { get; }

        public InjureView(AIViewEffectMgrBase<ActionEnum> mgr) : base(mgr)
        {

        }
    }
}
