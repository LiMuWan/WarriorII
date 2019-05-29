using Const;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Util;

namespace UIFrame
{
    public class ComicsManagerView : MonoBehaviour    
    {
        private readonly Dictionary<ComicsParentId, Transform> parentDic = new Dictionary<ComicsParentId, Transform>();

        public void Start()        
        {
            InitParent();
            InitButtons();
        }

        private void InitParent()
        {
            Transform parent = transform.GetByName("Parent");
            Transform temp;
            foreach (ComicsParentId id in Enum.GetValues(typeof(ComicsParentId)))
            {
                var list = from Transform child in parent where child.name.Contains(id.ToString()) select child;
                temp = list.FirstOrDefault();
                if (temp == null)
                {
                    Debug.LogError("can not find child name :" + id);
                    continue;
                }
                else
                {
                    parentDic[id] = temp;
                }
            }
        }

        private void InitButtons()
        {
            transform.AddBtnListener("Back",() => { });
            transform.AddBtnListener("Left", () => { });
            transform.AddBtnListener("Right", () => { });
            transform.AddBtnListener("Done", () => { });
        }
    }
}
