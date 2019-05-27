using Const;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace UIFrame
{
    public class StartGameView : BasicUI  
    {
        public override List<Transform> GetBtnParents()
        {
            List<Transform> transforms = new List<Transform>();
            transforms.Add(transform.GetBtnParent());
            return transforms;
        }
        public override UiId GetUiId()
        {
            return UiId.StartGame;
        }

        protected override void Init()        
        {
            transform.AddBtnListener("Continue" , () => { });
            transform.AddBtnListener("Easy", () => { });
            transform.AddBtnListener("Normal", () => { });
            transform.AddBtnListener("Hard", () => { });
        }
    }
}
