using DG.Tweening;
using UnityEngine;

namespace Game.Effect
{
    public class TrailsEffect : MonoBehaviour
    {
        private float duration;
        private Material material;
        private string colorName;

        public void Init()
        {
            duration = 0.3f;
            colorName = "_TintColor";
            material = transform.GetComponent<MeshRenderer>().material;
        }

        public void Show()
        {
            Effect(1,0.2f);
        }

        public void Hide()
        {
            Effect(0,0);
        }

        public void HideNow()
        {
            var color = material.GetColor(colorName);
            color.a = 0;
            material.SetColor(colorName, color);
        }

        private void Effect(float endValue,float delay)
        {
            material.DOFade(endValue, "_TintColor", duration).SetDelay(delay);
        }
    }
}
