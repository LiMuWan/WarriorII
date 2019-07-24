using Game.Interface;
using Game.Model;
using Manager;
using System.Collections.Generic;

namespace Game.Service
{

    public interface IModelService:IInitService     
    {
    }

    public interface IConfigModelService : IModelService
    {
    }

    /// <summary>
    /// 配置数据服务
    /// </summary>
    public class ConfigModelService:IConfigModelService     
    {

        public  void Init(Contexts contexts)        
        {
            InitValidHumanSkillModel(contexts);
        }

        public  int GetPriority()         
        {
            return 0;
        }

        private void InitValidHumanSkillModel(Contexts contexts)
        {
            List<ValidHumanSkill> skills = GetValidHumanSkillList();
            int maxLength = GetMaxLenthItem(skills);
            contexts.game.SetGameModelHumanSkillConfig(skills,maxLength);
        }

        private List<ValidHumanSkill> GetValidHumanSkillList()
        {
            SkillCodeMudule codeMudule = new SkillCodeMudule();

            List<ValidHumanSkill> skills = new List<ValidHumanSkill>();
            int codeTemp = 0;
            foreach (HumanSkillModel model in ModelManager.Single.HumanSkillDataModel.Skills)
            {
                //配置数据关卡小于角色当前关卡
                if (model.Level <= (int)DataManager.Single.LevelIndex)
                {
                    codeTemp = codeMudule.GetSkillCode(model.Code, "", "");
                    skills.Add(new ValidHumanSkill(codeTemp));
                }
            }
            return skills;
        }

        /// <summary>
        /// 获取到技能编码的最大有效长度
        /// </summary>
        /// <param name="skills"></param>
        /// <returns></returns>
        private int GetMaxLenthItem(List<ValidHumanSkill> skills)
        {
            int length = 0;
            foreach (ValidHumanSkill skill in skills)
            {
                if(skill.Code.ToString().Length > length)
                {
                    length = skill.Code.ToString().Length;
                }
            }
            return length;
        }
    }
}
