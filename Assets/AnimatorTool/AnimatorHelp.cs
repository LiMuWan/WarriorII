using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomTool
{
    public class AnimatorHelp:StateMachineBehaviour     
    {
        public AnimatorController Controller { get; set; }
        public AnimatorState AnimatorState { get; set; }
        public Dictionary<AnimatorStateTransition, bool> TransitionsDic { get; set; }
        public List<AnimatorStateTransition> TransitionsList { get; set; }
        public bool IsSelectAllTransition { get; set; }

        [MultiSelectEnum]
        public ParaEnum SelectDataToChange;
        public CustomTransitionPara TransitionPara;

        public void InitTransitionsDic()
        {
            if (TransitionsDic != null) return;
            TransitionsList = new List<AnimatorStateTransition>();
            TransitionsDic = new Dictionary<AnimatorStateTransition, bool>();
            foreach (AnimatorStateTransition transition in AnimatorState.transitions)
            {
                TransitionsList.Add(transition);
                TransitionsDic[transition] = false;
            }
        }

        /// <summary>
        /// 位运算处理枚举
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public bool GetSelectedData(ParaEnum para)
        {
            return (SelectDataToChange & para) == para;
        }
    }

    [Flags]//这个特性可以进行位运算，
    public enum ParaEnum
    {
        HasExitTime = 1,
        ExitTime = 2,
        FixedDuration = 4,
        TransitionDuration = 8,
        TransitionOffset = 16,
        InterruptionSource = 32
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class MultiSelectEnumAttribute : PropertyAttribute
    {
        public MultiSelectEnumAttribute()
        {

        }
    }

    [System.Serializable]
    public class CustomTransitionPara
    {
        public bool HasExitTime;
        public float ExitTime;
        public bool FixedDuration;
        public float TransitionDuration;
        public float TransitionOffset;
        public TransitionInterruptionSource InterruptionSource;
    }
}
