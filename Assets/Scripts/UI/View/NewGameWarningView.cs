using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class NewGameWarningView : OverlayUI    
    {
        public override List<Transform> GetBtnParents()
        {
            List<Transform> list = new List<Transform>();
            list.Add(transform.Find("Buttons"));
            return list;
        }

        public override UiId GetUiId()
        {
            return UiId.NewGameWarning;
        }

        protected override void Init()
        {
           transform.AddBtnListener("Yes", () => 
           {
               DataManager.Single.ResetData();
               RootManager.Instance.Show(UiId.Loading);
           });
           transform.AddBtnListener("No", () => { RootManager.Instance.Back(); });
        }

        protected override void Show()
        {
            base.Show();
        }

        protected override void Hide()
        {
            base.Hide();
        }
    }
}
