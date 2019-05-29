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
            transform.AddBtnListener("Continue" , () => 
            {
                LoadScene(true);         
            });
            transform.AddBtnListener("Easy", () => 
            {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.Easy;
            });
            transform.AddBtnListener("Normal", () => 
            {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.Normal;
            });
            transform.AddBtnListener("Hard", () => 
            {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.Hard;
            });
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
            if(isContinue)
            {
                Continue();
            }
            else
            {
                NewGame();
            } 
        }

        private void NewGame()
        {
            if (DataManager.Single.JudgeExistData())
            {
                RootManager.Instance.Show(UiId.NewGameWarning);
            }
            else
            {
                RootManager.Instance.Show(UiId.Loading);
            }
        }

        private void Continue()
        {
            RootManager.Instance.Show(UiId.Loading);
        }
    }
}
