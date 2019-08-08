using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Util;

namespace CustomTool
{
    public class GenerateController
    {
        public void Create(string path, string name,List<AnimationClip> clips)
        {
            AnimatorController ctrl = AnimatorController.CreateAnimatorControllerAtPath(path + "/" + name + ".controller");
            AnimatorStateMachine machine = ctrl.GetAnimatorStateMachine(0);
            AddAnimationClips(machine, clips);
        }

        private void AddAnimationClips(AnimatorStateMachine machine,List<AnimationClip> clips)
        {
            foreach (AnimationClip clip in clips)
            {
                machine.AddState(clip.name);
                
            }
        }
    }
}
