using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    public class AutoAddNameSpace : UnityEditor.AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");
            if(path.EndsWith(".cs"))
            {
                string text = "";
                //读取xml和json建议用File.ReadAllText，因为它会自动的关闭IO流
                text += File.ReadAllText(path);
                string name = GetClassName(text);
                if (string.IsNullOrEmpty(name))
                {
                    return;
                }
                var newText = GetNewScriptContext(name);
                File.WriteAllText(path, newText); 
            }
            AssetDatabase.Refresh();
        }

        private static void CreateClass()
        {
             
        }

        private static string GetNewScriptContext(string className)
        {
            var script = new ScriptBuildHelp();
            script.WriteUsing("UnityEngine");
            script.WriteEmptyLine();
            script.WriteNameSpace("UIFrame");
            script.IndentTimes++;
            script.WriteClass(className);
            script.IndentTimes++;
            script.WriteFun("Start");

            return script.ToString();
        }

        private static string GetClassName(string text)
        {
            string[] data = text.Split(' ');

            int index = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if(data[i].Contains("class"))
                {
                    index = i + 1;
                    break;
                }
            }

            if(data[index].Contains(":"))
            {
               return data[index].Split(':')[0];
            }
            else
            {
                return data[index];
            }
        }

        private static string GetClassName1(string text)
        {
            //匹配模式 \s代表空格 
            string patterm = "public class ([A-Za-z0-9_]+)\\s*:\\s*MonoBehaviour";
            var match = Regex.Match(text, patterm);
            if(match.Success)
            {
                return match.Groups[1].Value;
            }

            return "";
        }
    }
}


