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
        public ScriptBuildHelp()
        {
            stringBuilder = new StringBuilder();
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
            int length = WriteCurlyBrackets();
            currentIndex -= length;
        }

        public void WriteClass(string name)
        {
            Write("public class " + name + " : MonoBehaviour",true);
            int length = WriteCurlyBrackets();
            currentIndex -= length;
        }

        public void WriteFun(string name,params string[] paraName)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("public void " + name + "()");
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
