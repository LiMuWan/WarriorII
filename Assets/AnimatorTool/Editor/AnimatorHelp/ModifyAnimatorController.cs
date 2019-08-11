using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AnimatorHelp),true)]
    public class ModifyAnimatorController:Editor     
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Toggle(true, "sss");
        }
    }
}
