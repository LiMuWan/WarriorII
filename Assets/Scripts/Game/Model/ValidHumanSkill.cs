using UnityEngine;

namespace Game.Model
{
    /// <summary>
    /// 有效技能数据
    /// </summary>
    public class ValidHumanSkill
    {
        public ValidHumanSkill(string code,int level)
        {
            Code = code;
            Level = level;
        }

        public string Code { get; private set; }
        public int Level { get; private set; }
    }
}
