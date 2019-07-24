
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

namespace Game.Model
{
    [Game,Unique]
    public class HumanSkillConfigComponent:IComponent
    {
        public List<ValidHumanSkill> ValidHumanSkills;

        /// <summary>
        /// 技能有效编码的最大长度
        /// </summary>
        public int LengthMax;
    }
}