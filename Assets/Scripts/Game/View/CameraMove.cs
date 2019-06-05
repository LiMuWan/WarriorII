 using UnityEngine;
using DG.Tweening;

namespace Game
{
    /// <summary>
    /// �����������
    /// </summary>
    public class CameraMove : MonoBehaviour    
    { 

        /// <summary>
        /// �����ʼ��
        /// </summary>
        /// <param name="targetParent"></param>
        public void Init(Transform targetParent)
        {
            SetParent(targetParent);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="targetParent"></param>
        public void Move(Transform targetParent)
        {
            transform.SetParent(targetParent);
            float time = 2f;

            transform.DOKill();
            transform.DOLocalMove(Vector3.zero, time);
            transform.DOLocalRotate(Vector3.zero, time);
        }

        /// <summary>
        /// ���ø�����
        /// </summary>
        /// <param name="targetParent"></param>
        public void SetParent(Transform targetParent)
        {
            transform.SetParent(targetParent);
        }
    }
}
