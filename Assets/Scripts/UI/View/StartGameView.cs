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
            transform.AddBtnListener("Easy", () => {  LoadScene(); });
            transform.AddBtnListener("Normal", () => {  LoadScene(); });
            transform.AddBtnListener("Hard", () => {  LoadScene(); });
        }

        protected override void Show()
        {
            base.Show();
            SetContinueBtnState();
        }

        private void SetContinueBtnState()
        {
            if(!DataManager.JudgeExistData())
            {
                transform.GetBtnParent().Find("Continue").gameObject.SetActive(false);
            }
            else
            {
                transform.GetBtnParent().Find("Continue").gameObject.SetActive(true);
            }
        }

        private void LoadScene()
        {
            if(DataManager.JudgeExistData())
            {
                RootManager.Instance.Show(UiId.NewGameWarning);
            }
            else
            {
                //LoadScene() Todo
            }
        }
    }
}
