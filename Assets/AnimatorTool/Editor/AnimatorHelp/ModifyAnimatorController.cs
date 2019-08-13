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
            base.DrawDefaultInspector();
            GUILayout.Label("批量修改过渡状态");

            SelectAllTransition();
            TransitionToggle();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(help);
            }
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

        private void SelectAllTransition()
        {
            help.IsSelectAllTransition = GUILayout.Toggle(help.IsSelectAllTransition,"全选");
            if (help.IsSelectAllTransition)
            {
                foreach (AnimatorStateTransition transition in help.TransitionsList)
                {
                    help.TransitionsDic[transition] = true;
                }
            }
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
