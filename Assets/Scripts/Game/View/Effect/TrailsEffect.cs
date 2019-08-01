using DG.Tweening;
using UnityEngine;

namespace Game.Effect
{
    public class TrailsEffect : MonoBehaviour
    {
        private float duration;
        private Material material;

        public void Init()
        {
            duration = 0.3f;
            material = transform.GetComponent<MeshRenderer>().material;
        }

        public void Show()
        {
            Effect(1);
        }

        public void Hide()
        {
            Effect(0);
        }

        private void Effect(float endValue)
        {
            material.DOFade(endValue, "_TintColor", duration);
        }
    }
}
