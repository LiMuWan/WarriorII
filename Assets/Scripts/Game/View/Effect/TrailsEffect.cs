using DG.Tweening;
using UnityEngine;

namespace Game.Effect
{
    public class TrailsEffect : MonoBehaviour
    {
        private Material material;
        private float clipLength;
        private Sequence sequence;
        private string colorName = "_TintColor";

        public void Init(float clipLength)
        {
            this.clipLength = clipLength;
            material = transform.GetComponent<MeshRenderer>().material;
        }

        public void Show()
        {
            float duration = 0.2f;
            float intervalTime = 0.2f;
            string colorName = "_TintColor";
            float showTime = clipLength - intervalTime - duration * 2 - 0.2f;
            if (sequence != null)
            {
                sequence.Kill();
            }
            sequence = DOTween.Sequence();
            sequence.AppendInterval(intervalTime);
            sequence.Append(material.DOFade(1, colorName, duration));
            sequence.AppendInterval(showTime);
            sequence.Append(material.DOFade(0, colorName, duration));
        }

        public void HideNow()
        {
            var color = material.GetColor(colorName);
            color.a = 0;
            material.SetColor(colorName, color);
        }
    }
}
