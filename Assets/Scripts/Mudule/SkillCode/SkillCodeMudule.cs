using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SkillCodeMudule 
{
    public int GetCurrentSkillCode(SkillButton button, int currentCode)
    {
        int code = (int)button;
        if(currentCode < 0)
        {
            Debug.LogError("SkillCode不能小于0");
        }
        else if(currentCode == 0)
        {
            //第一次按键
            currentCode = code;
        }
        else
        {
            currentCode = currentCode * 10 + code;
        }
        return currentCode;
    }

    /// <summary>
    /// 通过技能名称获得技能编码
    /// </summary>
    /// <param name="skillName"></param>
    /// <param name="prefix"></param>
    /// <param name="posfix"></param>
    /// <returns></returns>
    public int GetSkillCode(string skillName,string prefix,string posfix)
    {
        string codeString = "";
        if(!string.IsNullOrEmpty(prefix))
        {
            codeString = skillName.Remove(0, prefix.Length);
        }
        if(!string.IsNullOrEmpty(posfix))
        {
            codeString = skillName.Remove(skillName.Length - posfix.Length, posfix.Length);
        }
        return ConvertStringToInt(codeString);
    }

    /// <summary>
    /// 转换技能名称字符串到int编码
    /// </summary>
    /// <param name="codeString"></param>
    /// <returns></returns>
    private int ConvertStringToInt(string codeString)
    {
        int[] codes = new int[codeString.Length];
        char[] chars = codeString.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if(chars[i] == SkillButton.O.ToString()[0])
            {
                codes[i] = (int)SkillButton.O;
            }
            else if(chars[i] == SkillButton.X.ToString()[0])
            {
                 codes[i] = (int)SkillButton.X;
            }
        }

        int code = 0;
        for (int i = 0; i < codes.Length; i++)
        {
            code += codes[i] * (int)(Mathf.Pow(10, codes.Length - 1 - i));
        }

        return code;
    }

    /// <summary>
    /// 转换int编码到技能名称字符串
    /// </summary>
    /// <param name="skillCode"></param>
    /// <returns></returns>
    private string ConvertIntToString(int skillCode)
    {
        string codeString = skillCode.ToString();
        string[] codeStrings = new string[codeString.Length];

        for (int i = 0; i < codeStrings.Length; i++)
        {
            if(int.Parse(codeString[i].ToString()) == (int)SkillButton.O)
            {
                codeStrings[i] = SkillButton.O.ToString();
            }
            else if(int.Parse(codeString[i].ToString()) == (int)SkillButton.X)
            {
                codeStrings[i] = SkillButton.X.ToString();
            }
        }

       codeString = string.Join("", codeStrings);    
        return codeString;
    }
    public enum SkillButton
    {
        O = 1,
        X = 2,
    }
}
