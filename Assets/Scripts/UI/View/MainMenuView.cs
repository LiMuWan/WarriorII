using Const;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class MainMenuView : BasicUI    
    {
        public override List<Transform> GetBtnParents()
        {
            List<Transform> transforms = new List<Transform>();
            transforms.Add(transform.Find("Buttons"));
            return transforms;
        }

        public override UiId GetUiId()
        {
            return UiId.MainMenu;
        }

        public void Start()        
        {
            transform.Find("Buttons/StartGame").RectTransform().AddBtnListener(() => RootManager.Instance.Show(UiId.StartGame));
            transform.Find("Buttons/DOJO").RectTransform().AddBtnListener(() => { });
            transform.Find("Buttons/Help").RectTransform().AddBtnListener(() => { });
            transform.Find("Buttons/ExitGame").RectTransform().AddBtnListener(() => Application.Quit());
        }
    }
}
