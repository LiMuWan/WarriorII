using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class SpawEnemyModel
    {
        public List<LevelModel> Level_1;
    }

    [Serializable]
    public class LevelModel
    {
        public string PointId;
        public int EnemyId;
    }
}
