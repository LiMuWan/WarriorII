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
    }
}
