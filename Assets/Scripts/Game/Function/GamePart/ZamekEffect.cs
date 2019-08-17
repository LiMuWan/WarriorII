using DG.Tweening;
using UnityEngine;

namespace Game.GamePart
{
    public class ZamekEffect:MonoBehaviour     
    {
        private Vector3 defaultScale;
        private float duration;

        public void Init()
        {
            defaultScale = transform.localScale;
            duration = 1.5f;
        }

        public void OpenZamekState(bool isOpen)
        {
            if(isOpen)
            {
                HideZamek();
            }
            else
            {
                ShowZamek();
            }
        }

        private void ShowZamek()
        {
            transform.DOKill();
            transform.localScale = Vector3.zero;
            
            transform.DOScale(defaultScale,duration).SetEase(Ease.InElastic);
        }

        private void HideZamek()
        {
            transform.DOKill();
            transform.localScale = defaultScale;

            transform.DOScale(Vector3.zero, duration);
        }
    }
}
