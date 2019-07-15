using System.Collections;
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
            currentCode =(int)(code * Mathf.Pow(10, GetCodeLength(currentCode))) + currentCode;
        }
        return currentCode;
    }

    /// <summary>
    /// 获取当前编码是几位数
    /// </summary>
    /// <param name="currentCode"></param>
    /// <returns></returns>
    private int GetCodeLength(int currentCode)
    {
        return currentCode.ToString().Length;
    }

    public enum SkillButton
    {
        ATTACK_O = 1,
        ATTACK_X = 2,
    }
}
