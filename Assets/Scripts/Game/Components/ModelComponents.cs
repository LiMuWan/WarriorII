
using Entitas;
using System.Collections.Generic;

namespace Game.Model
{
    [Game]
    public class HumanSkillConfigComponent:IComponent
    {
        public List<ValidHumanSkill> ValidHumanSkills;
    }
}