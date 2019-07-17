﻿using System.Collections;
using System.Collections.Generic;
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

    //转换string编码到int
    public int ConvertStringToInt(string codeString)
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

    public enum SkillButton
    {
        O = 1,
        X = 2,
    }
}
