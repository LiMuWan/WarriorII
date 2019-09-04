using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [SerializeField]
    public class SpawEnemyModel
    {
        public List<LevelModel> Levels;
    }

    [SerializeField]
    public class LevelModel
    {
        public List<PointModel> PointList;
    }

    [SerializeField]
    public class PointModel
    {
        public string PointId;
        public int EnemyId;
    }
}
