using Const;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class BtnParent : MonoBehaviour    
    {
        private List<BtnSelected> childs;
        public SelectedState SelectedState
        {
            set
            {
                ResetChildState();
                if(value == SelectedState.SELECTED)
                {
                    childs[childId].SelectedState = SelectedState.SELECTED;
                }
            }
        }
        public int ChildCount
        {
            get { return childs.Count; } private set { } 
        }

        public int Index { get;private set; }
        private int childId;
        public void Init(int index)
        {
            Index = index;
            childs = new List<BtnSelected>();
            foreach (Transform trans in transform)
            {
              childs.Add (trans.gameObject.AddComponent<BtnSelected>());
            }
        }

        public void SetDefaultBtn()
        {
           if(childs.Count > 0)
            {
                childs[0].Selected();
            }
        }

        public void SelectedDefault()
        {
            Selected(childs[0].transform);
        }

        public void Selected(Transform selected)
        {
            BtnSelected btn = selected.GetComponentInChildren<BtnSelected>();
            if(btn != null)
            {
                btn.Selected();
            }
        }

        public void CancelSelected()
        {

        }

        public bool Left()
        {
            childId--;
            if(childId >= 0)
            {
                Selected(childs[childId].transform);
                return true;
            }
            else
            {
                childId = 0;
                return false;
            }
        }

        public bool Right()
        {
            childId++;
            if(childId < childs.Count)
            {
                Selected(childs[childId].transform);
                return true;
            }
            else
            {
                childId = ChildCount - 1;
                return false;
            }
        }

        private void ResetChildState()
        {
            foreach (BtnSelected child in childs)
            {
                child.SelectedState = SelectedState.UNSELECTED;
            }
        }
    }
}
