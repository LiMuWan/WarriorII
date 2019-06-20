using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomTool
{
    public class ScriptBuildHelp
    {
        private StringBuilder stringBuilder;

        private string lineBreak = "\r\n";

        private int currentIndex = 0;
        public int IndentTimes { get; set; }
        /// <summary>
        /// 回到大括号中间，需要缩进的值
        /// </summary>
        private int backNum;
        public ScriptBuildHelp()
        {
            stringBuilder = new StringBuilder();
            backNum = WriteCurlyBrackets();
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

        private void WriteLine(string context,bool needIndent = false)
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

        public void WriteFun(List<string> keyName, string name,params string[] paraName)
        {
            StringBuilder keyTemp = new StringBuilder();
            for (int i = 0; i < keyName.Count; i++)
            {
                keyTemp.Append(keyName[i]);
                if(i != keyName.Count - 1)
                {
                    keyTemp.Append(" ");
                }
            }

            StringBuilder temp = new StringBuilder();
            temp.Append("public " + keyTemp + " " + name + "()");
            if (paraName != null && paraName.Length > 0)
            {
                foreach (var s in paraName)
                {
                    temp.Insert(temp.Length - 1, s + ",");
                }
                temp.Remove(temp.Length - 2, 1);
            }
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

        /// <summary>
        /// 添加方法内容
        /// </summary>
        /// <param name="contentLine"></param>
        public void WriteFuncContent(string contentLine)
        {
            WriteLine(contentLine, true);
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
