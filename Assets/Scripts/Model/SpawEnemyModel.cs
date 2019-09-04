using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class SpawEnemyModel
    {
        public List<LevelModel> Levels = new List<LevelModel>();
    }

    [Serializable]
    public class LevelModel
    {
        public List<PointModel> PointList = new List<PointModel>();
    }

    [Serializable]
    public class PointModel
    {
        public string PointId;
        public int EnemyId;
    }
}
