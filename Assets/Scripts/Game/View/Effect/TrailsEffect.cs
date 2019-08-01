using DG.Tweening;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Effect
{
    public class TrailsEffect : MonoBehaviour
    {
        private Material material;
        private Material dustMaterial;
        private Color dustDefaultColor;
        private float clipLength;
        private Sequence sequence;
        private string colorName = "_TintColor";
        private Animation dustAnimation;

        public void Init(float clipLength)
        {
            this.clipLength = clipLength;
            material = transform.GetComponent<MeshRenderer>().material;
            InitDust();
        }

        private void InitDust()
        {
            dustAnimation = transform.GetComponentInChildren<Animation>();
            //if (dustAnimation != null)
            //{
            //    dustMaterial = transform.GetChild(0).GetComponentInChildren<MeshRenderer>().material; 
            //    dustDefaultColor = dustMaterial.GetColor(colorName);
            //}
        }

        public void Show()
        {
            float duration = 0.2f;
            float intervalTime = 0.2f;
            string colorName = "_TintColor";
            float showTime = clipLength - intervalTime - duration * 2 - 0.2f;

            Light(intervalTime, duration, showTime);
            ShowDust();
            Shake(intervalTime + showTime * 0.5f);
        }

        public void HideNow()
        {
            var color = material.GetColor(colorName);
            color.a = 0;
            material.SetColor(colorName, color);
            SetDustActive(false);
        }

        private void ShowDust()
        {
            if(dustAnimation == null)
            {
                return;
            }
            //dustMaterial.SetColor(colorName, dustDefaultColor);
            SetDustActive(true);
            dustAnimation.Play();
            StopAllCoroutines();
            StartCoroutine(WaitDustEnd());
        }

        private IEnumerator WaitDustEnd()
        {
            float length = dustAnimation.clip.length;
            yield return new WaitForSeconds(length);
            SetDustActive(false);
        }

        private void SetDustActive(bool isActive)
        {
            if(dustAnimation == null)
            {
                return;
            }
            dustAnimation.gameObject.SetActive(isActive);
        }

        private void Light(float intervalTime, float duration, float showTime)
        {
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

        private async void Shake(float delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            Contexts.sharedInstance.game.ReplaceGameCameraState(CameraAniName.SHAKE);
        }
    }
}
