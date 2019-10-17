using System.Collections.Generic;
using BlueGOAP;
using Const;
using Game.AI.ViewEffect;
using UnityEngine;

namespace Game.AI
{
    public abstract class BodyTrigger : TriggerBase
    {
        protected Vector3 _center;
        protected Vector3 _direction;
        protected float _height;
        protected Vector3 _hitPosition;
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
            _height = controller.height;
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
                _hitPosition = other.transform.position;
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

        protected void SetColliderData(ActionEnum actionEnum , bool result)
        {
            var dic = GetGameData<Dictionary<ActionEnum, bool>>(GameDataKeyEnum.INJURE_COLLECT_DATA);
            dic[actionEnum] = result;
        }

        protected float GetHeightValue(float scale)
        {
            float headTop = _center.y + _height * 0.5f;
            float height = headTop - _height * (scale / Const.ALL_BODY_SACLE);
            return height;
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
                SetColliderData(ActionEnum.INJURE_UP, result);
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
                SetColliderData(ActionEnum.INJURE_DOWN, result);
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
                SetColliderData(ActionEnum.INJURE_LEFT, result);
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
                SetColliderData(ActionEnum.INJURE_RIGHT, result);
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

    public class BodyHeadTrigger : BodyTrigger
    {
        public override bool IsTrigger 
        {
            get
            {
                if (_hitPosition == Vector3.zero)
                    return false;

                bool result = false;
                float headTop = _center.y + _height * 0.5f;
                float headBottom = headTop - _height * (Const.HEAD_SCALE / Const.ALL_BODY_SACLE);
                if(_hitPosition.y > headBottom && _hitPosition.y < headTop)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                _hitPosition = Vector3.zero;
                SetColliderData(ActionEnum.DEAD_HALF_HEAD, result);
                return result;
            }
            set { }
        }
        public BodyHeadTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        } 
    }

    public class BodyBodyTrigger : BodyTrigger
    {
        public override bool IsTrigger 
        {
            get 
            {
                if (_hitPosition == Vector3.zero)
                    return false;

                bool result = false;
                float headTop = GetHeightValue(0);
                float bodyTop = headTop - GetHeightValue(Const.HEAD_SCALE);
                float bodyBottom = headTop - _height * GetHeightValue(Const.HEAD_SCALE + Const.BODY_SCALE);
                if (_hitPosition.y > bodyBottom && _hitPosition.y < bodyTop)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                _hitPosition = Vector3.zero;
                SetColliderData(ActionEnum.DEAD_HALF_BODY, result);
                return result;
            }
            set { }
        }

        public BodyBodyTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }
    }

    public class BodyLegTrigger : BodyTrigger
    {
        public BodyLegTrigger(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {

        }

        public override bool IsTrigger 
        {
            get 
            {
                if (_hitPosition == Vector3.zero)
                    return false;

                bool result = false;
                float headTop = GetHeightValue(0);
                float legTop = headTop - GetHeightValue(Const.HEAD_SCALE + Const.BODY_SCALE);
                float legBottom = headTop - GetHeightValue(Const.HEAD_SCALE + Const.BODY_SCALE + Const.LEG_SCALE);
                if (_hitPosition.y > legBottom && _hitPosition.y < legTop)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                _hitPosition = Vector3.zero;
                SetColliderData(ActionEnum.DEAD_HALF_LEG, result);
                return result;
            }
            set { }
        }
    }
}
