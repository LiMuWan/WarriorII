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
                //���Ʊ��� ��״̬��index
                GUI.Label(position, label);

                var name = property.FindPropertyRelative("SubMachineName");
                var anis = property.FindPropertyRelative("AnimationObjects");

                //������״̬������
                var nameRect = new Rect(position)
                {
                    y = position.y + EditorGUIUtility.singleLineHeight,
                    height = EditorGUIUtility.singleLineHeight
                }; 

                //���ƶ���Ƭ�θ���������
                var aniRect = new Rect(position)
                {
                    y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.singleLineHeight
                };

                EditorGUI.PropertyField(nameRect, name, new GUIContent("��״̬������"));
                EditorGUI.PropertyField(aniRect, anis, new GUIContent("����Ƭ�θ���������"),true);
            }
        }
    }
}
