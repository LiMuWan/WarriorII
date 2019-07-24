using CustomTool;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Game.Editor
{
    /// <summary>
    /// 生成类模板
    /// </summary>
    public class CodeTemplate
    {
        /// <summary>
        /// 获取View类通用代码
        /// </summary>
        /// <returns></returns>
        public static string GetViewCode()
        {
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteUsing("Entitas.Unity");
            build.WriteNameSpace(ToolData.namespaceBase + "." + ToolData.viewPostfix);

            build.IndentTimes++;
            //class
            build.WriteClass(ToolData.viewName + ToolData.viewPostfix, "ViewBase");
            //Init
            List<string> keyName = new List<string>();
            keyName.Add("override");
            keyName.Add("void");
            build.IndentTimes++;
            build.WriteFun("Init", ScriptBuildHelp.Public, keyName, "", "Contexts contexts", "IEntity entity");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("base.Init(contexts,entity);", true);
            build.ToContentEnd();
            return build.ToString();
        }

        /// <summary>
        /// 获取Service类通用代码
        /// </summary>
        /// <returns></returns>
        public static string GetServiceCode()
        {
            ScriptBuildHelp build = new ScriptBuildHelp();
            string className = ToolData.serviceName + ToolData.servicePostfix;
            build.WriteUsing("Game.Interface");
            build.WriteEmptyLine();
            build.WriteNameSpace(ToolData.namespaceBase + "." + ToolData.servicePostfix);
            build.WriteEmptyLine();
            build.IndentTimes++;
            build.WriteInterface("I" + className, "IInitService");
            build.ToContentEnd();

            build.WriteEmptyLine();
            //class
            build.WriteClass(className, "I" + className);
            var keyName = new List<string>();
            keyName.Add("void");
            build.IndentTimes++;
            //Init
            build.WriteFun("Init", ScriptBuildHelp.Public, keyName, "", "Contexts contexts");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("//contexts.service.SetGameService" + className + "(this);", true);
            build.IndentTimes--;
            build.ToContentEnd();
            build.WriteEmptyLine();

            var key = new List<string>();
            key.Add("int");
            //GetPriority
            build.WriteFun("GetPriority", ScriptBuildHelp.Public, key);
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("return 0;", true);
            build.IndentTimes--;
            build.ToContentEnd();
            return build.ToString();
        }

        /// <summary>
        /// 获取ReactiveSystem通用代码
        /// </summary>
        /// <returns></returns>
        public static string GetReactiveSystemCode()
        {
            string className = ToolData.selectedContextName + ToolData.systemName + ToolData.systemPosfix;
            string entityName = ToolData.selectedContextName + "Entity";
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteUsing("System.Collections.Generic");
            build.WriteEmptyLine();
            //class
            build.WriteClass(className, "ReactiveSystem<" + entityName + ">");
            build.IndentTimes++;
            build.WriteLine("protected Contexts contexts;", true);
            build.WriteEmptyLine();
            //构造
            build.WriteFun(className, ScriptBuildHelp.Public, new List<string>(), ": base(contexts."+ ToolData.selectedContextName.ToLower() + ")", "Contexts contexts");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("this.contexts = contexts;", true);
            build.IndentTimes--;
            build.ToContentEnd();
            build.WriteEmptyLine();

            //GetTrigger
            List<string> triggerKeys = new List<string>();
            triggerKeys.Add("override");
            triggerKeys.Add("ICollector<" + entityName + ">");
            build.WriteFun("GetTrigger", ScriptBuildHelp.Protected, triggerKeys, " ", "IContext<" + entityName + "> context");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("return context.CreateCollector(" + ToolData.selectedContextName + "Matcher." + ToolData.selectedContextName + ToolData.systemName + ");", true);
            build.IndentTimes--;
            build.ToContentEnd();
            build.WriteEmptyLine();
            //Filter
            List<string> filterKeys = new List<string>();
            filterKeys.Add("override");
            filterKeys.Add("bool");
            build.WriteFun("Filter", ScriptBuildHelp.Protected, filterKeys, "", entityName + " " + "entity");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("return entity.has" + ToolData.selectedContextName + ToolData.systemName + ";", true);
            build.IndentTimes--;
            build.ToContentEnd();
            build.WriteEmptyLine();
            //Execute
            List<string> executeKeys = new List<string>();
            executeKeys.Add("override");
            executeKeys.Add("void");
            build.WriteFun("Execute", ScriptBuildHelp.Protected, executeKeys, "", "List<" + entityName + "> entities");
            return build.ToString();
        }

        /// <summary>
        /// 获取继承指定接口的System通用代码
        /// </summary>
        /// <returns></returns>
        public static string GetOtherSystemCode()
        {
            string className = ToolData.selectedContextName + ToolData.otherSystemName + ToolData.systemPosfix;
            List<string> selectedSystem = GetSelectedSystem();
            ScriptBuildHelp build = new ScriptBuildHelp();
            build.WriteUsing("Entitas");
            build.WriteNameSpace(ToolData.namespaceBase);
            build.IndentTimes++;
            //class
            build.WriteClass(className, GetSelectedSystem(selectedSystem));
            build.IndentTimes++;
            build.WriteLine("protected Contexts contexts;", true);
            build.WriteEmptyLine();
            //构造
            build.WriteFun(className, ScriptBuildHelp.Public, new List<string>(), " ", "Contexts contexts");
            build.BackToInsertContent();
            build.IndentTimes++;
            build.WriteLine("this.contexts = contexts;", true);
            build.IndentTimes--;
            build.ToContentEnd();
            //实现方法
            List<string> funcName = GetFuncName(selectedSystem);
            List<string> keyName = new List<string>();
            keyName.Add("void");
            foreach (string func in funcName)
            {
                build.WriteEmptyLine();
                build.WriteFun(func, ScriptBuildHelp.Public, keyName);
            }

            return build.ToString();
        }

        /// <summary>
        /// 获取当前选中的所有接口的名字集合
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSelectedSystem()
        {
            List<string> temp = new List<string>();
            foreach (KeyValuePair<string, bool> pair in ToolData.systemSelectedStateDic)
            {
                if (pair.Value)
                {
                    temp.Add(pair.Key);
                }
            }

            return temp;
        }

        /// <summary>
        /// 获取当前选中的所有接口，并用","连接起来的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetSelectedSystem(List<string> selected)
        {
            if (selected.Count == 0)
            {
                Debug.Log("未选择继承System接口");
                return null;
            }

            StringBuilder build = new StringBuilder();
            foreach (string pair in selected)
            {
                build.Append(pair);
                build.Append(" , ");
            }
            build.Remove(build.Length - 3, 3);
            return build.ToString();
        }

        /// <summary>
        /// 根据继承的所有接口，获取其对应的所有的实现方法名字，
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        public static List<string> GetFuncName(List<string> selected)
        {
            List<string> temp = new List<string>();
            foreach (string interfaceName in selected)
            {
                temp.Add(interfaceName.Substring(1, interfaceName.Length - 7));
            }
            return temp;
        }
    }
}
