using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace CustomTool
{
    public class CustomReorderableList
    {
        private ReorderableList reorderableList;
        private SerializedProperty property;

        public  CustomReorderableList(SerializedObject serializedObject,SerializedProperty property)
        {
            this.property = property;
            reorderableList = new ReorderableList(serializedObject, property);
            Init();
        }

        private void Init()
        {
            //����б�Ļ����¼�
            reorderableList.drawHeaderCallback = rect =>
            {
                GUI.Label(rect, "��״̬���б�");
            };

            reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                SerializedProperty item = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                //������UI������ʾ
                EditorGUI.PropertyField(rect, item, new GUIContent("��״̬��" + index),true);
            };

            reorderableList.onAddCallback = list =>
            {
                //����ԭ�ȵĻص�����
                //list.serializedProperty.arraySize++;
                //list.index++;
                ReorderableList.defaultBehaviours.DoAddButton(list);
                SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex(list.index);
                var name = item.FindPropertyRelative("SubMachineName");
                var anis = item.FindPropertyRelative("AnimationObjects");
                name.stringValue = "";
                anis.arraySize = 0;
            };

            //����������ĸ߶�����Ӧ
            reorderableList.elementHeightCallback = index =>
            {
                var element = property.GetArrayElementAtIndex(index);
                var name = element.FindPropertyRelative("SubMachineName");
                var anis = element.FindPropertyRelative("AnimationObjects");
                return EditorGUI.GetPropertyHeight(name) + EditorGUI.GetPropertyHeight(anis) + EditorGUIUtility.singleLineHeight + 5;
            };

            reorderableList.onRemoveCallback = list =>
            {
                //�Ի�����ʾ
                if (EditorUtility.DisplayDialog("�Ƴ���״̬��Ԫ��", "�Ƿ��Ƴ���ǰԪ��", "��", "��"))
                {
                    ReorderableList.defaultBehaviours.DoRemoveButton(list);
                }
            };
        }

        public void OnGUI()
        {
            reorderableList.DoLayoutList();
        }
    }
}
