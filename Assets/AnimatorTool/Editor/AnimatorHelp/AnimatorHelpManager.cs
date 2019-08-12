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

        public AnimatorController Add()
        {
            AnimatorController aniCtrl = Selection.activeObject as AnimatorController;
            for (int i = 0; i < aniCtrl.layers.Length; i++)
            {
                AddInLayer(aniCtrl,i);
            }
            return aniCtrl;
           // aniCtrl.GetAnimatorState(0);
        }

        private void AddInLayer(AnimatorController aniCtrl,int layer)
        {
            AnimatorState[] aniStates = aniCtrl.GetAnimatorStates(layer);
            AddHelp(aniCtrl,aniStates);
            AddInSubAnimatorMachine(aniCtrl, layer);
        }

        private void AddHelp(AnimatorController aniCtrl, AnimatorState[] aniStates)
        {
            bool has = false;
            foreach (AnimatorState state in aniStates)
            {
                has = false;
                foreach (StateMachineBehaviour behaviour in state.behaviours)
                {
                    if(behaviour is AnimatorHelp)
                    {
                        has = true;
                        break;
                    }
                }
                if (!has)
                {
                   var help = state.AddStateMachineBehaviour<AnimatorHelp>();
                   help.name = aniCtrl.name + "#" + state.nameHash.ToString(); 
                }
            }
        }

        private void AddInSubAnimatorMachine(AnimatorController aniCtrl, int layer)
        {
            AnimatorStateMachine[] machines = aniCtrl.GetSubStateMachines(layer);
            foreach (AnimatorStateMachine machine in machines)
            {
                AnimatorState[] states = machine.GetAnimatorStates();
                AddHelp(aniCtrl,states);
            }
        }
    }
}
