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
            //添加列表的绘制事件
            reorderableList.drawHeaderCallback = rect =>
            {
                GUI.Label(rect, "子状态机列表");
            };

            reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                SerializedProperty item = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
                //让子项UI正常显示
                EditorGUI.PropertyField(rect, item, new GUIContent("子状态机" + index),true);
            };

            reorderableList.onAddCallback = list =>
            {
                //覆盖原先的回调方法
                //list.serializedProperty.arraySize++;
                //list.index++;
                ReorderableList.defaultBehaviours.DoAddButton(list);
                SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex(list.index);
                var name = item.FindPropertyRelative("SubMachineName");
                var anis = item.FindPropertyRelative("AnimationObjects");
                name.stringValue = "";
                anis.arraySize = 0;
            };

            //绘制整个表的高度自适应
            reorderableList.elementHeightCallback = index =>
            {
                var element = property.GetArrayElementAtIndex(index);
                var name = element.FindPropertyRelative("SubMachineName");
                var anis = element.FindPropertyRelative("AnimationObjects");
                return EditorGUI.GetPropertyHeight(name) + EditorGUI.GetPropertyHeight(anis) + EditorGUIUtility.singleLineHeight + 5;
            };

            reorderableList.onRemoveCallback = list =>
            {
                //对话框提示
                if (EditorUtility.DisplayDialog("移除子状态机元素", "是否移除当前元素", "是", "否"))
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
