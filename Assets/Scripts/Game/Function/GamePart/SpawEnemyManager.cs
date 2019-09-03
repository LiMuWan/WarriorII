using System.Collections.Generic;
using Manager;
using UnityEngine;
using Util;

namespace Game.GamePart
{
    public class SpawEnemyManager:MonoBehaviour     
    {
        private HashSet<SpawEnemy> activeEnemies;
        private HashSet<SpawEnemy> inactiveEnemies;

        public  void Init()         
        {
            activeEnemies = new HashSet<SpawEnemy>();
            inactiveEnemies = new HashSet<SpawEnemy>();

            InitEnemy();
            Spaw();
        }

        private void InitEnemy()
        {
            SpawEnemy enemyTemp = null;
            foreach (Transform trans in transform)
            {
                enemyTemp = trans.GetOrAddComponent<SpawEnemy>();
                enemyTemp.Init(RemoveEnemyCallBack);
                inactiveEnemies.Add(enemyTemp);
            }
        }

        private void RemoveEnemyCallBack(SpawEnemy enemy)
        {
            activeEnemies.Remove(enemy);
            Spaw();
        }

        private void Spaw()
        {
            int count = GetSpawNum();
            SpawEnemy enemyTemp = null;

            for (int i = 0; i < count; i++)
            {
                enemyTemp = inactiveEnemies.GetEnumerator().Current;
                activeEnemies.Add(enemyTemp);
                inactiveEnemies.Remove(enemyTemp);
                enemyTemp.Spaw();
            }
        }

        private int GetSpawNum()
        {
            return ModelManager.Single.EnemyModel.SpawLimitNum - activeEnemies.Count;
        }
    }
}
