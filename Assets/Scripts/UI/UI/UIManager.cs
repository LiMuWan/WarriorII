using Const;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace UIFrame
{
    public class UIManager : MonoBehaviour    
    {
        public static UIManager Instance { get; private set; }

        private readonly Dictionary<UiId, GameObject> prefabDictionary = new Dictionary<UiId, GameObject>();
        private readonly Stack<UIBase> uiStack = new Stack<UIBase>();
        private UILayerManager uiLayerManager;
        private UIEffectManager uiEffectManager;
        private void Awake()
        {
            Instance = this;
            uiLayerManager = GetComponent<UILayerManager>();
            if(uiLayerManager == null)
            {
                Debug.LogErrorFormat("can not find UILayerManager");
            }
            uiEffectManager = GetComponent<UIEffectManager>();
            if(uiEffectManager == null)
            {
                Debug.LogErrorFormat("can not find UIEffectManager");
            }
        }

        private async void Start()
        {
            Show(UiId.MainMenu);

            await Task.Delay(TimeSpan.FromSeconds(1));

            //Show(UiId.StartGame);

            //await Task.Delay(TimeSpan.FromSeconds(1));

            //Back();
        }
        public void Show(UiId id)
        {
            GameObject ui = GetPrefabObject(id);

            if(ui == null)
            {
                Debug.LogErrorFormat("can't find prefab,UiId == {0}", id.ToString());
                return;
            }

            UIBase uiScript = GetUIScript(ui,id);

            if (uiScript == null) return;

            InitUI(uiScript);

            if(uiScript.Layer == UILayer.BASIC_UI) //如果打开主界面，需要隐藏之前的界面
            {
                uiScript.UIState = UIState.SHOW;
                Hide();
            }
            else
            {
                uiScript.UIState = UIState.SHOW;
            }

            uiEffectManager.Show(ui.transform);
            uiStack.Push(uiScript);
        }

        public void InitUI(UIBase uiScript)
        {
            if(uiScript.UIState == UIState.NORMAL)
            {
                Transform ui = uiScript.transform;
                //根据层级信息，添加到对应的父物体下
                ui.SetParent(uiLayerManager.GetLayerObject(uiScript.Layer));
                ui.localPosition = Vector3.zero;
                ui.localScale = Vector3.one;
            }
        }

        public void Back()
        {
            if(uiStack.Count > 0)
            {
                UIBase hideUI = uiStack.Pop();
                if (hideUI.Layer == UILayer.BASIC_UI)
                {
                    hideUI.UIState = UIState.HIDE;
                    uiStack.Peek().UIState = UIState.SHOW;
                    uiEffectManager.Show(uiStack.Peek().transform);
                }
                else
                {
                    hideUI.UIState = UIState.HIDE;
                }
                uiEffectManager.Hide(hideUI.transform);
            }
            else
            {
                Debug.LogError("uiStack has one or no element");
            }
        }

        public void Hide()
        {
            if(uiStack.Count != 0)
            {
                uiEffectManager.Hide(uiStack.Peek().transform);
                uiStack.Peek().UIState = UIState.HIDE;
            }
        }

        public GameObject GetPrefabObject(UiId id)
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

        public UIBase GetUIScript(GameObject prefab,UiId id)
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

        public UIBase AddUIScript(GameObject prefab,UiId id)
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
    }
}
