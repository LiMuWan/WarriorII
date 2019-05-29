using UnityEngine;
using Const;
using System;

namespace UIFrame
{
    public class DataManager : MonoBehaviour    
    {
        public DifficultLevel GetDifficultLevel
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
    }
}
