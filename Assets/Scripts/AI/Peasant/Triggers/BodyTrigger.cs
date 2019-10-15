using BlueGOAP;
using Const;
using Game.AI.ViewEffect;
using UnityEngine;

namespace Game.AI
{
    public abstract class BodyTrigger : TriggerBase
    {
        private Vector3 _center;
        protected Vector3 _direction;

        public override int Priority { get;}

        public BodyTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            InitCenter();
            InitUnityTrigger();
        }

        private void InitCenter()
        {
            var _self = GetGameData<Transform>(GameDataKeyEnum.SELF_TRANS);
            var controller = _self.GetComponent<CharacterController>();
            _center = controller.center;
        }

        private void InitUnityTrigger()
        {
            var unityTrigger = GetGameData<UnityTrigger>(GameDataKeyEnum.UNITY_TRIGGER);
            if (unityTrigger != null)
            {
                unityTrigger.AddColliderListener(Collider);
            }
        }

        private void Collider(Collider other)
        {
            if(other.tag == TagAndLayer.WEAPON_TAG)
            {
                _direction = (other.transform.position - _center).normalized;
                _direction.z = 0;
            }
        }

        protected override IState InitEffects()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();
            state.Set(StateKeyEnum.IS_INJURE, true);
            return state;
        }
    }

    public class BodyUpTrigger : BodyTrigger
    {

        public override bool IsTrigger
        {
            get
            {
                if (_direction == Vector3.zero)
                    return false;

                var result = Vector3.Angle(Vector3.up, _direction) < Const.BODY_PART_RANGE;
                Debug.Log("与上方向的角度：" + Vector3.Angle(Vector3.up, _direction));
                _direction = Vector3.zero;
                return result;
            }
            set { }
        }

        public BodyUpTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class BodyDownTrigger : BodyTrigger
    {

        public override bool IsTrigger
        {
            get
            {
                if (_direction == Vector3.zero)
                    return false;

                var result = Vector3.Angle(Vector3.down, _direction) < Const.BODY_PART_RANGE;
                Debug.Log("与下方向的角度：" + Vector3.Angle(Vector3.down, _direction));
                _direction = Vector3.zero;
                return result;
            }
            set { }
        }

        public BodyDownTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class BodyLeftTrigger : BodyTrigger
    {

        public override bool IsTrigger
        {
            get
            {
                if (_direction == Vector3.zero)
                    return false;

                var result = Vector3.Angle(Vector3.left, _direction) < Const.BODY_PART_RANGE;
                Debug.Log("与左方向的角度：" + Vector3.Angle(Vector3.left, _direction));
                _direction = Vector3.zero;
                return result;
            }
            set { }
        }

        public BodyLeftTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }

    public class BodyRightTrigger : BodyTrigger
    {

        public override bool IsTrigger
        {
            get
            {
                if (_direction == Vector3.zero)
                    return false;

                var result = Vector3.Angle(Vector3.right, _direction) < Const.BODY_PART_RANGE;
                Debug.Log("与右方向的角度：" + Vector3.Angle(Vector3.right, _direction));
                _direction = Vector3.zero;
                return result;
            }
            set { }
        }

        public BodyRightTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }
    }
}
