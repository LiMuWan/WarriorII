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
        private AnimatorController controller;
        private AnimatorState animatorState;
        private Dictionary<int, Tuple<AnimatorStateTransition, bool>> transitionsDic;

        public void OnEnable()
        {
            InitData();
            InitTransitionsDic();
        }

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();

            foreach (KeyValuePair<int,Tuple<AnimatorStateTransition,bool>> pair in transitionsDic)
            {
               bool selected = GUILayout.Toggle(pair.Value.Item2,"To" + pair.Value.Item1.destinationState.name);
                transitionsDic[pair.Key] = new Tuple<AnimatorStateTransition, bool>(pair.Value.Item1, selected);
            }
        }

        private void InitData()
        {
            try
            {
                var help = target as AnimatorHelp;
                if (string.IsNullOrEmpty(help.name))
                {
                    Debug.LogError("Help的脚本名称为空");
                }
                else
                {
                    string[] data = help.name.Split('#');
                    string aniCtrlName = data[0];
                    int nameHash = int.Parse(data[1]);
                    controller = AnimatorToolWindow.HelpControllers.FirstOrDefault(u => u != null && u.name == aniCtrlName);
                    if (controller == null)
                    {
                        Debug.LogError("未找到对应状态机 名称为 ：" + aniCtrlName);
                    }
                    else
                    {
                        var states = controller.GetAllAnimatorStates();
                        animatorState = states.FirstOrDefault(u => u.nameHash == nameHash);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("类型转换出错");
                throw;
            }
        }

        private void InitTransitionsDic()
        {
            transitionsDic = new Dictionary<int, Tuple<AnimatorStateTransition, bool>>();
            foreach (AnimatorStateTransition transition in animatorState.transitions)
            {
                transitionsDic[transition.GetHashCode()] = new Tuple<AnimatorStateTransition, bool>(transition, false);
            }
        }
    }
}
