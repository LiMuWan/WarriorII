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
            transform.Find("Buttons/Continue").GetComponent<Button>().onClick.AddListener(() => { });
            transform.Find("Buttons/Easy").GetComponent<Button>().onClick.AddListener(() => { });
            transform.Find("Buttons/Normal").GetComponent<Button>().onClick.AddListener(() => { });
            transform.Find("Buttons/Hard").GetComponent<Button>().onClick.AddListener(() => { });
        }
    }
}
