using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AnimatorHelp),true)]
    public class ModifyAnimatorController:Editor     
    {
        public void OnEnable()
        {
            try
            {
                var help = target as AnimatorHelp;
                if(string.IsNullOrEmpty(help.name))
                {
                    Debug.LogError("Help的脚本名称为空");
                }
                else
                {
                    string[] data = help.name.Split('#');
                    string aniCtrlName = data[0];
                    int nameHash = int.Parse(Regex.Replace(data[1], @"[^0-9]+", ""));
                }
                
            }
            catch(Exception e)
            {
                Debug.LogError("类型转换出错");
                throw;
            }
        }

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            GUILayout.Toggle(true, "sss");
        }
    }
}
