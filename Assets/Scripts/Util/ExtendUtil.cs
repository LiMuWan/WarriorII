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
    }
}
