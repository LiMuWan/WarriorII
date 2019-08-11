using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Util;

namespace CustomTool
{
    public class AnimatorHelpManager:MonoBehaviour     
    {
        public void Add()
        {
            AnimatorController aniCtrl = Selection.activeObject as AnimatorController;
            aniCtrl.GetAnimatorState(0);
        }
    }
}
