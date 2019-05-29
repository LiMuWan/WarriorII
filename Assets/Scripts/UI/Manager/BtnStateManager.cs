using System.Collections.Generic;
using UnityEngine;
using Util;
using DG.Tweening;
using System.Linq;
using System;

namespace UIFrame
{
    public class BtnStateManager : MonoBehaviour    
    {
        private Dictionary<Transform, Color> defaultColorDic = new Dictionary<Transform, Color>();

        private Transform lastBtnTrans;

        private int parentId;

        private List<BtnParent> currentParents = new List<BtnParent>();   

        public void InitBtnParent(List<Transform> btnParents)
        {
            if (btnParents == null) return;

            BtnParent temp;
            for (int i = 0; i < btnParents.Count; i++)
            {
                temp = btnParents[i].gameObject.AddComponent<BtnParent>( );
                temp.Init(i);
            }
        }

        private bool JudgeException(List<Transform> parents)
        {
            return parents == null || parents.Count == 0;
        }

        public void SetDefaultBtn(List<BtnParent> parents)
        {
            foreach (BtnParent parent in parents)
            {
                if(parent.Index == 0)
                {
                    parent.SelectedDefault();
                }
            }
        }

        public void Show(Transform showUI)
        {
            ResetBtnState();
            ResetData();
            currentParents =  showUI.GetComponentsInChildren<BtnParent>(true).ToList();
            SetDefaultBtn(currentParents);
        }

        private void ResetData()
        {
            parentId = 0;
            currentParents.Clear();
        }

        public void Left()
        {
            MoveIndex(currentParents[parentId].Left, -1);
        }

        public void Right()
        {
            MoveIndex(currentParents[parentId].Right, 1);
        }

        private bool MoveIndex(Func<bool> moveAction,int symbol)
        {
            if (JudgeException(moveAction, symbol))
                return false;

            if(parentId >= 0 && parentId < currentParents.Count)
            {
                if(moveAction())
                {
                    currentParents[parentId].SelectedState = Const.SelectedState.SELECTED;
                    return true;
                }
                else
                {
                    currentParents[parentId].SelectedState = Const.SelectedState.UNSELECTED; //id改变之前把它设为未选中状态
                    parentId += symbol;
                    return MoveIndex(moveAction,symbol);
                }
            }
            else
            {
                ResetParentId();
                currentParents[parentId].SelectedState = Const.SelectedState.SELECTED; //复位的id设为选中状态 
                return true;
            }
        }

        private bool JudgeException(Func<bool> moveAction, int symbol)
        {
            if(moveAction == null)
            {
                Debug.LogError("moveAction is null! ");
                return true;
            }

            if(symbol != 1 && symbol != -1)
            {
                Debug.LogError("symbol must be 1 or -1 !!!");
                return true;
            }

            return false;
        }

        private void ResetParentId()
        {
            if(parentId <= 0)
            {
                parentId = 0;
                return;
            }
            else if(parentId >= currentParents.Count)
            {
                parentId = currentParents.Count - 1;
            }
        }

        public void SelectedButton()
        {
            currentParents[parentId].SelectedButton();
        }

        private void ResetBtnState()
        {
            foreach (var parent in currentParents)
            {
                parent.ResetChild();
            }
        }
    }
}
