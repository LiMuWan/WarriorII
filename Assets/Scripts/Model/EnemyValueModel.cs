using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class EnemyValueModel 
    {
        public List<EnemyData> EnemyList;
    }

    [Serializable]
    public class EnemyData
    {
        public string PrefabName;
        public int Life;
        public int Attack;
    }

    /// <summary>
    /// 怪物基础数值数据类
    /// </summary>
    public class EnemyDataModel
    {
        public Dictionary<EnemyId, EnemyData> DataDic;
    }
}
