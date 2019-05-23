using System;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public static class ExtendUtil   
    {
        public static void AddBtnListener(this RectTransform rect, Action action)
        {
            var button = rect.GetComponent<Button>() ?? rect.gameObject.AddComponent<Button>();

            button.onClick.AddListener(() => action());
        }

        public static RectTransform RectTransform(this Transform transform)
        {
            RectTransform rect = transform.GetComponent<RectTransform>();
            if(rect != null)
            {
                return rect;
            }
            else
            {
                Debug.LogErrorFormat("can't find rectTransform in this gameObject == {0}", transform.gameObject);
                return null;
            }
        }

        public static Image Image(this Transform transform)
        {
            Image image = transform.GetComponent<Image>();
            if (image != null)
            {
                return image;
            }
            else
            {
                Debug.LogErrorFormat("can't find image in this gameObject == {0}", transform.gameObject);
                return null;
            }
        }

        public static Button Button(this Transform transform)
        {
            Button button = transform.GetComponent<Button>();
            if (button != null)
            {
                return button;
            }
            else
            {
                Debug.LogErrorFormat("can't find button in this gameObject == {0}", transform.gameObject);
                return null;
            }
        }
    }
}
