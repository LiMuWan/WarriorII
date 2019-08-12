using System.Collections.Generic;
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
                if (instance == null)
                {
                    instance = new AnimatorHelpManager();
                }
                return instance;
            }
        }

        public AnimatorController Add()
        {
            AnimatorController aniCtrl = Selection.activeObject as AnimatorController;
            AddHelp(aniCtrl, aniCtrl.GetAllAnimatorStates());
            return aniCtrl;
            // aniCtrl.GetAnimatorState(0);
        }

        private void AddHelp(AnimatorController aniCtrl, List<AnimatorState> aniStates)
        {
            bool has = false;
            foreach (AnimatorState state in aniStates)
            {
                has = false;
                foreach (StateMachineBehaviour behaviour in state.behaviours)
                {
                    if (behaviour is AnimatorHelp)
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
    }
}
