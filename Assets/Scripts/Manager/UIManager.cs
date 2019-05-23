using Const;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class UIManager : MonoBehaviour    
    {
        private readonly Dictionary<UiId, GameObject> prefabDictionary = new Dictionary<UiId, GameObject>();
        private readonly Stack<UIBase> uiStack = new Stack<UIBase>();
        private Func<UILayer, Transform> GetLayerObject;

        public void AddGetLayerObjectListener(Func<UILayer, Transform> func)
        {
            if(func == null)
            {
                Debug.LogError("func could not be null");
                return;
            }
            GetLayerObject = func;
        }

        public Tuple<Transform, Transform> Show(UiId id)
        {
            GameObject ui = GetPrefabObject(id);

            if(ui == null)
            {
                Debug.LogErrorFormat("can't find prefab,UiId == {0}", id.ToString());
                return null;
            }

            UIBase uiScript = GetUIScript(ui,id);

            if (uiScript == null) return null;

            InitUI(uiScript);

            Transform hideUI = null;

            if(uiScript.Layer == UILayer.BASIC_UI) //如果打开主界面，需要隐藏之前的界面
            {
                uiScript.UIState = UIState.SHOW;
                hideUI = Hide();
            }
            else
            {
                uiScript.UIState = UIState.SHOW;
            }

            //uiEffectManager.Show(ui.transform);
            uiStack.Push(uiScript);

            return new Tuple<Transform,Transform>(ui.transform,hideUI);
        }

        private void InitUI(UIBase uiScript)
        {
            if(uiScript.UIState == UIState.NORMAL)
            {
                Transform ui = uiScript.transform;
                //根据层级信息，添加到对应的父物体下
                ui.SetParent(GetLayerObject(uiScript.Layer));
                ui.localPosition = Vector3.zero;
                ui.localScale = Vector3.one;
                ui.RectTransform().offsetMax = Vector2.zero;
                ui.RectTransform().offsetMin = Vector2.zero;
            }
        }

        public Tuple<Transform,Transform> Back()
        {
            if(uiStack.Count > 1)
            {
                UIBase hideUI = uiStack.Pop();
                Transform showUI = null;
                if (hideUI.Layer == UILayer.BASIC_UI)
                {
                    hideUI.UIState = UIState.HIDE;
                    uiStack.Peek().UIState = UIState.SHOW;
                    showUI = uiStack.Peek().transform;
                    //uiEffectManager.Show(uiStack.Peek().transform);
                }
                else
                {
                    hideUI.UIState = UIState.HIDE;
                }
                //uiEffectManager.Hide(hideUI.transform);

                return new Tuple<Transform, Transform>(showUI, hideUI.transform); 
            }
            else
            {
                Debug.LogError("uiStack has one or no element");
                return null;
            }
        }

        private Transform Hide()
        {
            if(uiStack.Count != 0)
            {
                //uiEffectManager.Hide(uiStack.Peek().transform);
                uiStack.Peek().UIState = UIState.HIDE;
                return uiStack.Peek().transform;
            }
            return null;
        }

        private GameObject GetPrefabObject(UiId id)
        {
             if(!prefabDictionary.ContainsKey(id))
             {
                GameObject prefab = LoadManager.Instance.Load<GameObject>(Path.UIPath, id.ToString());
                if (prefab != null)
                {
                    prefabDictionary[id] = Instantiate(prefab);
                }
                else
                {
                    Debug.LogErrorFormat("can't find prefab name : {0}", id.ToString());
                }
             }

            return prefabDictionary[id];
        }

        private UIBase GetUIScript(GameObject prefab,UiId id)
        {
            UIBase ui = prefab.GetComponent<UIBase>();
            if(ui == null)
            {
               return AddUIScript(prefab,id);
            }
            else
            {
                return ui;
            }
        }

        private UIBase AddUIScript(GameObject prefab,UiId id)
        {
            string scriptName = ConstValue.UI_NAMESPACE_NAME + "." + id + ConstValue.UI_SCRIPT_POSFIX;
            Type ui = Type.GetType(scriptName);
            if(ui == null)
            {
                Debug.LogErrorFormat("can't find this Script == {0}", prefab.name);
                return null;
            }
            else
            {
                return prefab.AddComponent(ui) as UIBase; 
            }
             
        }

        public List<Transform> GetBtnParents(Transform showUI)
        {
            if (showUI != null)
            {
                return showUI.GetComponent<UIBase>().GetBtnParents();
            }

            return null;
        }
    }
}
