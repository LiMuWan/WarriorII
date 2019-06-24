using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomTool
{
    public class ScriptBuildHelp
    {
        public static string Public = "public";
        public static string Private = "private";
        public static string Protected = "protected";
        private StringBuilder stringBuilder;

        private string lineBreak = "\r\n";

        private int currentIndex = 0;
        public int IndentTimes { get; set; }
        /// <summary>
        /// 回到大括号中间，需要缩进的值
        /// </summary>
        private int backNum
        {
            get { return (GetIndent() + "}" + lineBreak).Length; }
        }

        public ScriptBuildHelp()
        {
            stringBuilder = new StringBuilder();;
            ResetData();
        }

        public void ResetData()
        {
            stringBuilder.Clear();
            currentIndex = 0;
        }

        private void Write(string context, bool needIndent = false)
        {
            if(needIndent)
            {
                context = GetIndent() + context;
            }

            if(currentIndex == stringBuilder.Length)
            {
                stringBuilder.Append(context);
            }
            else
            {
                stringBuilder.Insert(currentIndex, context);
            }

            currentIndex += context.Length;
        }

        public void WriteLine(string context,bool needIndent = false)
        {
            Write(context + lineBreak, needIndent);
        }

        private string GetIndent()
        {
            string indent = "";
            for (int i = 0; i < IndentTimes; i++)
            {
                indent += "    "; 
            }
            return indent;
        }

        /// <summary>
        /// 返回值回到大括号中间，需要缩进的值
        /// </summary>
        /// <returns></returns>
        private int WriteCurlyBrackets()
        {
            string start = lineBreak + GetIndent() + "{" + lineBreak;
            string end = GetIndent() + "}" + lineBreak;
            Write(start + end, true);
            return end.Length;
            
        }

        public void WriteUsing(string nameSpaceName)
        {
            WriteLine("using " + nameSpaceName + ";");
        }

        public void WriteNameSpace(string name)
        {
            Write("namespace " + name);
            WriteCurlyBrackets();
            BackToInsertContent();
        }

        public void WriteClass(string name,params string[] baseName)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < baseName.Length; i++)
            {
                temp.Append(baseName[i]);
                if(i != baseName.Length - 1)
                {
                    temp.Append(",");
                }
            }
            Write("public class " + name + ":" + temp + " " ,true);
            WriteCurlyBrackets();
            BackToInsertContent();
        }

        public void WriteInterface(string name, params string[] baseName)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < baseName.Length; i++)
            {
                temp.Append(baseName[i]);
                if (i != baseName.Length - 1)
                {
                    temp.Append(",");
                }
            }
            Write("public interface " + name + ":" + temp + " ", true);
            WriteCurlyBrackets();
            BackToInsertContent();
        }
        //public void WriteFun(List<string> keyName, string publicState,string name, string others = " ", params string[] paraName)
        //{
        //    WriteFun(name, publicState, keyName, others, paraName);
        //}

        public void WriteFun(string name, string publicState, List<string> keyName,  string others = " ",params string[] paraName)
        {
            StringBuilder keyTemp = new StringBuilder();
            if (keyName != null)
            {
                for (int i = 0; i < keyName.Count; i++)
                {
                    keyTemp.Append(keyName[i]);
                    if (i != keyName.Count - 1)
                    {
                        keyTemp.Append(" ");
                    }
                }
            }

            StringBuilder temp = new StringBuilder();
            temp.Append(publicState + "  " +  keyTemp + " " + name + "()");
            if (paraName != null && paraName.Length > 0)
            {
                foreach (var s in paraName)
                {
                    temp.Insert(temp.Length - 1, s + ",");
                }
                temp.Remove(temp.Length - 2, 1);
            }
            temp.Append(others);
            Write(temp.ToString(), true);
            WriteCurlyBrackets();
        }

        /// <summary>
        /// 设置光标位置，给大括号内插入内容
        /// </summary>
        public void BackToInsertContent()
        {
            currentIndex -= backNum;
        }

        /// <summary>
        /// 设置光标位置，给结束大括号外
        /// </summary>
        public void ToContentEnd()
        {
            currentIndex += backNum;   
        }

        public void WriteEmptyLine()
        {
            WriteLine("");
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}
