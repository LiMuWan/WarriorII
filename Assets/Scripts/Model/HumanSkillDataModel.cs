using System.Collections.Generic;
using System;
namespace Game
{
    [Serializable]
    public class HumanSkillDataModel 
    {
        public List<HumanSkillModel> Skills;
    }

    [Serializable]
    public class HumanSkillModel
    {
        public string Code;
        public int Level;
    }
}
