using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    [CustomPropertyDrawer(typeof(SubAnimatorMachineItem))]
    public class SubAnimatorMachineItemShower:PropertyDrawer    
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (new EditorGUI.PropertyScope(position, label,property))
            {
                //绘制标题 子状态机index
                GUI.Label(position, label);

                var name = property.FindPropertyRelative("SubMachineName");
                var anis = property.FindPropertyRelative("AnimationObjects");

                //绘制子状态机名称
                var nameRect = new Rect(position)
                {
                    y = position.y + EditorGUIUtility.singleLineHeight,
                    height = EditorGUIUtility.singleLineHeight
                }; 

                //绘制动画片段父物体数组
                var aniRect = new Rect(position)
                {
                    y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.singleLineHeight
                };

                EditorGUI.PropertyField(nameRect, name, new GUIContent("子状态机名称"));
                EditorGUI.PropertyField(aniRect, anis, new GUIContent("动画片段父物体数组"),true);
            }
        }
    }
}
