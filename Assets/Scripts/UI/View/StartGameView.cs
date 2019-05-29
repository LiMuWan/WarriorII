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
            transform.AddBtnListener("Continue" , () => { LoadScene(true); });
            transform.AddBtnListener("Easy", () => {  LoadScene(false); });
            transform.AddBtnListener("Normal", () => {  LoadScene(false); });
            transform.AddBtnListener("Hard", () => {  LoadScene(false); });
        }

        protected override void Show()
        {
            base.Show();
            SetContinueBtnState();
        }

        private void SetContinueBtnState()
        {
            if(!DataManager.Single.JudgeExistData())
            {
                transform.GetBtnParent().Find("Continue").gameObject.SetActive(false);
            }
            else
            {
                transform.GetBtnParent().Find("Continue").gameObject.SetActive(true);
            }
        }

        private void LoadScene(bool isContinue)
        {
            if(DataManager.Single.JudgeExistData())
            {
                RootManager.Instance.Show(UiId.NewGameWarning);
            }
            else
            {
                StartLoading();
            }
        }

        private void StartLoading()
        {
            RootManager.Instance.Show(UiId.Loading);
        }
    }
}
