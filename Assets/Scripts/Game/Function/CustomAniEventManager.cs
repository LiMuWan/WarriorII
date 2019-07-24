using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using System;

namespace Game
{
    /// <summary>
    /// �Զ��嶯���¼�������
    /// </summary>
    public class CustomAniEventManager
    {
        private Dictionary<PlayerAniStateName, AnimatorState> stateDic;
        private Dictionary<PlayerAniStateName, CustomAniEvent> eventDic;

        public CustomAniEventManager(Animator animator)
        {
            stateDic = new Dictionary<PlayerAniStateName, AnimatorState>();
            eventDic = new Dictionary<PlayerAniStateName, CustomAniEvent>();

            InitAnimatorStateData(animator);
            
        }

        private void InitAnimatorStateData(Animator animator)
        {
            AnimatorController aniController = animator.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine aniMachine = aniController.layers[0].stateMachine;

            foreach (ChildAnimatorState state in aniMachine.states)
            {

                foreach (PlayerAniStateName stateName in Enum.GetValues(typeof(PlayerAniStateName)))
                {
                    if (state.state.name == stateName.ToString())
                    {
                        stateDic[stateName] = state.state;
                    }
                }

                if (!stateDic.ContainsValue(state.state))
                {
                    Debug.LogError("can not find Enum(PlayerAniStateName) name is " + state.state.name);
                }
            }
        }

        /// <summary>
        /// ����Զ����¼��ű�
        /// </summary>
        private void AddCustomAniEventScripts()
        {
            CustomAniEvent behaviourTemp = null;
            foreach (KeyValuePair<PlayerAniStateName,AnimatorState> pair in stateDic)
            {
                foreach (StateMachineBehaviour behaviour in pair.Value.behaviours)
                {
                    if(behaviour is CustomAniEvent)
                    {
                        behaviourTemp = behaviour as CustomAniEvent;
                        break;
                    }
                }

                if (behaviourTemp == null)
                {
                    eventDic[pair.Key] = pair.Value.AddStateMachineBehaviour<CustomAniEvent>();
                }
                else
                {
                    eventDic[pair.Key] = behaviourTemp;
                }
            }
        }
    }

    /// <summary>
    /// ����״̬���ƶ�Ӧö��
    /// </summary>
    public enum PlayerAniStateName
    {
        idle,
        walk,
        run,
        idleSword,
        walkSword,
        runSword
    }
}
