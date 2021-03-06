﻿using UnityEngine;
using Const;
using System;
using Util;
using UnityEngine.SceneManagement;
using Game;

namespace Manager
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

        /// <summary>
        /// 关卡数据标记，默认是1
        /// </summary>
        public LevelID  LevelIndex
        {
            set
            {
                if (value <= 0) return;
                PlayerPrefs.SetInt(ConstValue.LEVEL_INDEX, (int)value);
            }
            get
            {
               return (LevelID)PlayerPrefs.GetInt(ConstValue.LEVEL_INDEX,(int)LevelID.ONE);
            }
        }


        /// <summary>
        /// 关卡大区域部分的标记，默认是1
        /// </summary>
        public LevelGamePartID LevelGamePartIndex
        {
            set
            {
                if (value <= 0) return;
                PlayerPrefs.SetInt(ConstValue.LEVEL_GAME_PART_INDEX, (int)value);
            }
            get
            {
                return (LevelGamePartID)PlayerPrefs.GetInt(ConstValue.LEVEL_GAME_PART_INDEX, (int)LevelGamePartID.ONE);
            }
        }

        /// <summary>
        /// 关卡小区域部分的标记，默认是1
        /// </summary>
        public LevelPartID LevelPartIndex
        {
            set
            {
                if (value <= 0) return;
                PlayerPrefs.SetInt(ConstValue.LEVEL_PART_INDEX, (int)value);
            }
            get
            {
                return (LevelPartID)PlayerPrefs.GetInt(ConstValue.LEVEL_PART_INDEX, (int)LevelPartID.ONE);
            }
        }

        public bool JudgeExistData()
        {
            return DifficultLevel != DifficultLevel.None;
        }

        public void ResetData()
        {
            LevelIndex = LevelID.ONE;
            LevelGamePartIndex = LevelGamePartID.ONE;
            LevelPartIndex = LevelPartID.ONE;
        }

        public string GetSceneName()
        {
            if(JudgeCurrentScene(ConstValue.MAIN_SCENE))
            {
                return ConstValue.COMICS_SCENE;
            }
            else if(JudgeCurrentScene(ConstValue.COMICS_SCENE))
            {
                return ConstValue.LEVEL_SCENE + "_" + ((int)LevelIndex).ToString("00");
            }
            else
            {
                return "";
            }
        }

        private bool JudgeCurrentScene(string name)
        {
            return string.Equals(SceneManager.GetActiveScene().name , name);
        }
    }
}
