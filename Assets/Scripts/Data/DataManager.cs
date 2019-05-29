using UnityEngine;
using Const;
using System;
using Util;
using UnityEngine.SceneManagement;

namespace UIFrame
{
    public class DataManager : SingletonBase<DataManager>    
    {
        public DifficultLevel DifficultLevel
        {
            set { PlayerPrefs.SetString(ConstValue.DIFFICULT_LEVEL, value.ToString()); }
            get
            {
                string value = PlayerPrefs.GetString(ConstValue.DIFFICULT_LEVEL,DifficultLevel.None.ToString());
                DifficultLevel level;
                if (!Enum.TryParse(value, out level))
                {
                    Debug.LogError("parse DifficultLevel type fail");
                    return DifficultLevel.None;
                }
                else
                {
                    return level;
                }
            }
        }

        public int LevelIndex
        {
            set { PlayerPrefs.SetInt(ConstValue.LEVEL_INDEX, value); }
            get
            {
               return PlayerPrefs.GetInt(ConstValue.LEVEL_INDEX, 1);
            }
        }

        public int LevelPartIndex
        {
            set { PlayerPrefs.SetInt(ConstValue.LEVEL_PART_INDEX, value); }
            get
            {
                return PlayerPrefs.GetInt(ConstValue.LEVEL_PART_INDEX, 1);
            }
        }

        public bool JudgeExistData()
        {
            return DifficultLevel != DifficultLevel.None;
        }

        public string GetSceneName()
        {
            if(JudgeCurrentScene(ConstValue.MAIN_SCENE))
            {
                return ConstValue.COMICS_SCENE;
            }
            else if(JudgeCurrentScene(ConstValue.COMICS_SCENE))
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        private bool JudgeCurrentScene(string name)
        {
            return string.Equals(SceneManager.GetActiveScene() , name);
        }
    }
}
