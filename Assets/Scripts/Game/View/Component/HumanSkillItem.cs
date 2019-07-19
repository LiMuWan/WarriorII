using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class HumanSkillItem : MonoBehaviour
    {
        private HumanSkillSprite humanSkillSprite;
        private Image image;

        public void Init()
        {
            humanSkillSprite = GetComponent<HumanSkillSprite>();
            image = GetComponent<Image>();
        }

        public void ChangeSprite(char code)
        {
            if(code.ToString() == SkillCodeMudule.SkillButton.O.ToString())
            {
                image.sprite = humanSkillSprite.O;
                SetActive(true);
            }
            else if (code.ToString() == SkillCodeMudule.SkillButton.X.ToString())
            {
                image.sprite = humanSkillSprite.X;
                SetActive(true);
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
