using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Util;

namespace CustomTool
{
    public class AnimatorHelpManager
    {
        private static AnimatorHelpManager instance;

        public static AnimatorHelpManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AnimatorHelpManager();
                }
                return instance;
            }
        }

        public void Add()
        {
            AnimatorController aniCtrl = Selection.activeObject as AnimatorController;
            for (int i = 0; i < aniCtrl.layers.Length; i++)
            {
                AddInLayer(aniCtrl,i);
            }
           // aniCtrl.GetAnimatorState(0);
        }

        private void AddInLayer(AnimatorController aniCtrl,int layer)
        {
            AnimatorState[] aniStates = aniCtrl.GetAnimatorStates(layer);
            AddHelp(aniStates);
            AddInSubAnimatorMachine(aniCtrl, layer);
        }

        private void AddHelp(AnimatorState[] aniStates)
        {
            foreach (AnimatorState state in aniStates)
            {
                state.AddStateMachineBehaviour<AnimatorHelp>();
            }
        }

        private void AddInSubAnimatorMachine(AnimatorController aniCtrl, int layer)
        {
            AnimatorStateMachine[] machines = aniCtrl.GetSubStateMachines(layer);
            foreach (AnimatorStateMachine machine in machines)
            {
                AnimatorState[] states = machine.GetAnimatorStates();
                AddHelp(states);
            }
        }
    }
}
