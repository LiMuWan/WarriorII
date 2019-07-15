using Game.Interface;

namespace Game.Service
{

    public interface ISkillCodeService:IInitService     
    {
        int GetCurrentSkillCode(InputButton button, int currentCode);
    }

    public class SkillCodeService:ISkillCodeService     
    {

        private SkillCodeMudule skillCodeMudule;
        public  void Init(Contexts contexts)        
        {
            contexts.service.SetGameServiceSkillCodeService(this);
        }

        public  int GetPriority()         
        {
            return 0;
        }

        public int GetCurrentSkillCode(InputButton button,int currentCode)
        {
            if (button == InputButton.ATTACK_O )
            {
               return skillCodeMudule.GetCurrentSkillCode(SkillCodeMudule.SkillButton.ATTACK_O,currentCode);
            }
            else if (button == InputButton.ATTACK_X)
            {
                return skillCodeMudule.GetCurrentSkillCode(SkillCodeMudule.SkillButton.ATTACK_X, currentCode);
            }
            else
            {
                return 0;
            }
        }
    }
}
