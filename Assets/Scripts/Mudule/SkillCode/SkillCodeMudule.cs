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
            currentCode = currentCode * 10 + code;
        }
        return currentCode;
    }

    public enum SkillButton
    {
        ATTACK_O = 1,
        ATTACK_X = 2,
    }
}
