using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Util;

namespace CustomTool
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AnimatorHelp),true)]
    public class ModifyAnimatorController:Editor     
    {
        private AnimatorHelp help;

        public void OnEnable()
        {
            InitData();
            help.InitTransitionsDic();
        }

        public override void OnInspectorGUI()
        {
            AddFun(true,"请选择要修改的过渡状态", () =>
             {
                 SelectAllTransition();
                 TransitionToggle();
             });

            AddFun(GetTransitionState(),"修改参数", () =>
             {
                 base.DrawDefaultInspector();
             }
            );

            if(GUILayout.Button("确认修改"))
            {
                if (EditorUtility.DisplayDialog("确认修改", "是否确认修改当前选中过渡状态数据", "是", "否"))
                {
                    ChangeTransitionData();
                }
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(help);
            }
        }

        private void ChangeTransitionData()
        {
            foreach (KeyValuePair<AnimatorStateTransition,bool> pair in help.TransitionsDic)
            {
                if(pair.Value)
                {
                    foreach (ParaEnum value in Enum.GetValues(typeof(ParaEnum)))
                    {
                        var to = pair.Key.GetType().GetProperty(value.ToString());
                        var from = help.TransitionPara.GetType().GetField(value.ToString());
                        to.SetValue(pair.Key, from.GetValue(help.TransitionPara));
                    }
                }
            }
            EditorUtility.DisplayDialog("", "修改完成", "是");
        }

        private void InitData()
        {
            try
            {
                help = target as AnimatorHelp;
                if (string.IsNullOrEmpty(help.name))
                {
                    Debug.LogError("Help的脚本名称为空");
                }
                else
                {
                    string[] data = help.name.Split('#');
                    string aniCtrlName = data[0];
                    int nameHash = int.Parse(data[1]);
                    help.Controller = AnimatorToolWindow.HelpControllers.FirstOrDefault(u => u != null && u.name == aniCtrlName);
                    if (help.Controller == null)
                    {
                        Debug.LogError("未找到对应状态机 名称为 ：" + aniCtrlName);
                    }
                    else
                    {
                        var states = help.Controller.GetAllAnimatorStates();
                        help.AnimatorState = states.FirstOrDefault(u => u.nameHash == nameHash);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("类型转换出错");
                throw;
            }
        }

        private void AddFun(bool isShow, string title,Action action)
        {
            if (!isShow)
                return;

            EditorGUILayout.BeginVertical(GUI.skin.box);

            GUILayout.SelectionGrid(0, new string[] { title }, 1);
            action?.Invoke();

            EditorGUILayout.EndVertical();

            GUILayout.Space(10);
        }

        private void SelectAllTransition()
        {
            bool lastToggleState = help.IsSelectAllTransition;
            help.IsSelectAllTransition = GUILayout.Toggle(help.IsSelectAllTransition,"全选");
            if (help.IsSelectAllTransition)
            {
                SetTransitionToggleState(true);
            }
            else
            {
                if (help.IsSelectAllTransition != lastToggleState)
                {
                    SetTransitionToggleState(false);
                }
            }
        }

        private void SetTransitionToggleState(bool isSelect)
        {
            foreach (AnimatorStateTransition transition in help.TransitionsList)
            {
                help.TransitionsDic[transition] = isSelect;
            }
        }

        private bool GetTransitionState()
        {
            foreach (AnimatorStateTransition transition in help.TransitionsList)
            {
               if(help.TransitionsDic[transition])
                {
                    return true;
                }
            }

            return false;
        }

        private void TransitionToggle()
        {
            foreach (AnimatorStateTransition transition in help.TransitionsList)
            {
                help.TransitionsDic[transition] = GUILayout.Toggle(help.TransitionsDic[transition], "To  " + transition.destinationState.name);
                if(!help.TransitionsDic[transition])
                {
                    help.IsSelectAllTransition = false;
                }
            }
        }
    }
}
