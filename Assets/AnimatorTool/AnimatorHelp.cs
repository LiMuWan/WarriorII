using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomTool
{
    public class AnimatorHelp:StateMachineBehaviour     
    {
        public AnimatorController controller;
        public AnimatorState animatorState;
        public Dictionary<AnimatorStateTransition, bool> transitionsDic;
        public List<AnimatorStateTransition> transitions;

        public void InitTransitionsDic()
        {
            if (transitionsDic != null) return;
            transitions = new List<AnimatorStateTransition>();
            transitionsDic = new Dictionary<AnimatorStateTransition, bool>();
            foreach (AnimatorStateTransition transition in animatorState.transitions)
            {
                transitions.Add(transition);
                transitionsDic[transition] = false;
            }
        }
    }
}
