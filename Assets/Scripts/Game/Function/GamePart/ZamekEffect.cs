using DG.Tweening;
using UnityEngine;

namespace Game.GamePart
{
    public class ZamekEffect:MonoBehaviour     
    {
        private Vector3 defaultScale;
        private float duration;
        private float punchDuration;

        public void Init()
        {
            defaultScale = transform.localScale;
            duration = 0.7f;
            punchDuration = 0.3f;
        }

        public void OpenZamekState(bool isOpen)
        {
            if(isOpen)
            {
                ShowZamek();
            }
            else
            {
                HideZamek();
            }
        }

        private void ShowZamek()
        {
            transform.DOKill();
            transform.localScale = Vector3.zero;
            
            transform.DOScale(defaultScale,duration);
            transform.DOPunchScale(Vector3.one, punchDuration);
        }

        private void HideZamek()
        {
            transform.DOKill();
            transform.localScale = defaultScale;

            transform.DOScale(Vector3.zero, duration);
            transform.DOPunchScale(Vector3.one, punchDuration);
        }
    }
}
