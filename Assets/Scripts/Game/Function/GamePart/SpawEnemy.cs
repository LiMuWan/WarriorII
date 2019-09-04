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
        private int id;


        public void Init(int id, Action<SpawEnemy> removeCallBack)         
        {
            this.id = id;
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
            if(model == null)
            {
                Debug.LogError("在配置文件中，未找到对应敌方数据");
                return EnemyId.EnemyPeasant.ToString();
            }

            return ((EnemyId)model.EnemyId).ToString();
        }

        private string GetPointId()
        {
            int gamePart = (int)DataManager.Single.LevelGamePartIndex;
            int part = (int)DataManager.Single.LevelPartIndex;

            return gamePart + "_" + part + "_" + id;
        }
    }
}
