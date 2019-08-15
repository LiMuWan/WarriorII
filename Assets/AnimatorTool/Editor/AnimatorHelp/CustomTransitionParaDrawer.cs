using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    public class CustomTransitionParaDrawer:PropertyDrawer    
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using(new EditorGUI.PropertyScope(position, label, property))
            {

            }
        }
    }

    [CustomPropertyDrawer(typeof(MultiSelectEnumAttribute))]
    public class MultiSelectEnumDrawer:PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent lable)
        {
            using (new EditorGUI.PropertyScope(position,lable,property))
            {
                property.intValue = EditorGUILayout.MaskField("选择当前需要修改的参数", property.intValue,
                    property.enumDisplayNames);
            }
        }
    }
}
