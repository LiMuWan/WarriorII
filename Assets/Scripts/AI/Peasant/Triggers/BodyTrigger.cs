using BlueGOAP;
using Const;
using Game.AI.ViewEffect;
using UnityEngine;

namespace Game.AI
{
    public abstract class BodyTrigger : TriggerBase
    {
        public BodyTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            var unityTrigger = GetGameData<UnityTrigger>(GameDataKeyEnum.UNITY_TRIGGER);
            if(unityTrigger != null)
            {
                unityTrigger.AddColliderListener(Collider);
            }
        }

        private void Collider(Collider other)
        {
            if(other.tag == TagAndLayer.WEAPON_TAG)
            {

            }
        }

        //获取到当前碰撞体的中心
        //获取到武器和碰撞体的第一个接触点
    }

    public class BodyUpTrigger : BodyTrigger
    {
        public override int Priority { get;}

        public override bool IsTrigger { get; set; }

        public BodyUpTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitEffects()
        {
            return new State();
        }
    }
}
