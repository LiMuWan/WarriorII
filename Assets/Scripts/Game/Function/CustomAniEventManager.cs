using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using System;

namespace Game
{
    public interface ICustomAniEventManager
    {
        void AddEventListener(Action<string> OnStateEnterAction, Action<string> OnStateUpdateAction, Action<string> OnStateExitAction);
    }

    /// <summary>
    /// 自定义动画事件管理类
    /// </summary>
    public class CustomAniEventManager:ICustomAniEventManager
    {
        private Dictionary<PlayerAniStateName, AnimatorState> stateDic;
        private Dictionary<PlayerAniStateName, CustomAniEvent> eventDic;

        public CustomAniEventManager(Animator animator)
        {
            stateDic = new Dictionary<PlayerAniStateName, AnimatorState>();
            eventDic = new Dictionary<PlayerAniStateName, CustomAniEvent>();

            InitAnimatorStateData(animator);
            AddCustomAniEventScripts();
            InitCustomAniEventScripts();
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

        private void InitCustomAniEventScripts()
        {
            foreach (KeyValuePair<PlayerAniStateName,CustomAniEvent> pair in eventDic)
            {
                pair.Value.Init(pair.Key);
            }
        }

        /// <summary>
        /// 添加自定义事件脚本
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

        public void AddEventListener(Action<string> OnStateEnterAction, Action<string> OnStateUpdateAction, Action<string> OnStateExitAction)
        {
            foreach (KeyValuePair<PlayerAniStateName,CustomAniEvent> pair in eventDic)
            {
                pair.Value.OnStateEnterAction = OnStateEnterAction;
                pair.Value.OnStateUpdateAction = OnStateUpdateAction;
                pair.Value.OnStateExitAction = OnStateExitAction;
            }
        }
    }

    /// <summary>
    /// 动画状态名称对应枚举
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
