﻿using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.Effect
{
    public static class ShowAndHideEffect
    {
        /// <summary>
        /// 渐显当前物体及子物体所有的Image
        /// </summary>
        /// <param name="go"></param>
        /// <param name="duration"></param>
        public static void ShowImage(this GameObject go, float duration)
        {
            foreach (Image image in go.transform.GetComponentsInChildren<Image>())
            {
                KillImageEffect(image);
                image.DOFade(1, duration);
            }
        }

        /// <summary>
        /// 渐隐当前物体及子物体所有的Image
        /// </summary>
        /// <param name="go"></param>
        /// <param name="duration"></param>
        public static void HideImage(this GameObject go, float duration)
        {
            foreach (Image image in go.transform.GetComponentsInChildren<Image>())
            {
                KillImageEffect(image);
                image.DOFade(0, duration);
            }
        }

        private static void KillImageEffect(Image image)
        {
            image.DOKill();
        }
    }
}
