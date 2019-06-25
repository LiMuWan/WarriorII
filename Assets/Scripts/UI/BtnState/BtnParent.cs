using Const;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class BtnParent : MonoBehaviour    
    {
      
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
        private List<BtnSelected> childs;
        private int childId;
       
        public void Init(int index)
        {
            Index = index;
            childId = 0;
            childs = new List<BtnSelected>();
            BtnSelected temp;
            foreach (Transform trans in transform)
            {
               temp = trans.gameObject.AddComponent<BtnSelected>();
                temp.AddSelectButtonByMouseListener(SelectButtonByMouse);
               childs.Add (temp);
            }
        }

        private void SelectButtonByMouse(BtnSelected btn)
        {
            childId = btn.Index;
            ResetChildState();
            btn.SelectedState = SelectedState.SELECTED;
        }

        public void SelectedDefault()
        {
            Selected(childs[0].transform);
        }

        private void Selected(Transform selected)
        {
            BtnSelected btn = selected.GetComponentInChildren<BtnSelected>();
            if(btn != null)
            {
                btn.Selected();
            }
        }

        public void SelectedButton()
        {
            childs[childId].SelectedButton();
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

        public void ResetChild()
        {
            ResetChildState();
        }
    }
}
