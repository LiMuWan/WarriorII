using System;
using System.Collections.Generic;
using System.Linq;
using Const;
using Manager;
using UnityEngine;

namespace Game
{
    public class SpawEnemy:MonoBehaviour     
    {
        private Action<SpawEnemy> removeCallBack;

        public void Init(Action<SpawEnemy> removeCallBack)         
        {
            this.removeCallBack = removeCallBack;
        }

        public void Spaw()
        {
            Contexts.sharedInstance.service.gameServiceLoadService.LoadService.LoadEnmey(GetEnemyName(),transform);
        }

        private string GetEnemyName()
        {
            var model = ModelManager.Single.SpawEnemyModel;
            int levelIndex = (int)DataManager.Single.LevelIndex - 1;
            var points = model.Levels[levelIndex].PointList;
            return GetEnemyName(points);
        }

        private string GetEnemyName(List<PointModel> points)
        {
            var model = points.FirstOrDefault(u => u.PointId == GetPointId());
            return ((EnemyId)model.EnemyId).ToString();
        }

        private string GetPointId()
        {
            int gamePart = (int)DataManager.Single.LevelGamePartIndex;
            int part = (int)DataManager.Single.LevelPartIndex;

            return gamePart + "_" + part + "_" + GetCurrentPointId();
        }

        private string GetCurrentPointId()
        {
            var data = transform.name.Split('_');
            return data[1];
        }
    }
}
