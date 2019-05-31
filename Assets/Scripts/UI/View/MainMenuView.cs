using Const;
using Manager;
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
            transforms.Add(transform.GetBtnParent());
            return transforms;
        }

        public override UiId GetUiId()
        {
            return UiId.MainMenu;
        }

        protected override void Init()
        {
            transform.AddBtnListener("StartGame", () => { RootManager.Instance.Show(UiId.StartGame); });
            transform.AddBtnListener("DOJO", () => { });
            transform.AddBtnListener("Help", () => { });
            transform.AddBtnListener("ExitGame", () => { Application.Quit(); });
        }
    }
}
