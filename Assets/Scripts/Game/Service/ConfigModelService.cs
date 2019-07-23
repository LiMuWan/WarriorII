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

            contexts.game.SetGameModelHumanSkillConfig(skills);
        }
    }
}
