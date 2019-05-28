using Const;
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

        public static void AddBtnListener(this Transform transform, Action action)
        {
            var button = transform.GetComponent<Button>() ?? transform.gameObject.AddComponent<Button>();

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

        public static Transform GetBtnParent(this Transform transform)
        {
            var parent = transform.Find(ConstValue.BUTTON_PARENT_NAME);
            if(parent == null)
            {
                Debug.LogError("can not find btn parent : " + ConstValue.BUTTON_PARENT_NAME);
                return null;
            }
            else
            {
                return parent;
            }
        }

        public static void AddBtnListener(this Transform transform , string btnName , Action callBack)
        {
            var btnTrans = transform.Find(ConstValue.BUTTON_PARENT_NAME + "/" + btnName);
            if(btnTrans == null)
            {
                Debug.LogError("can not find btnName : " + btnName);
            }
            else
            {
                btnTrans.AddBtnListener(callBack);
            }
        }
    }
}
