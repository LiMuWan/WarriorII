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
        }

        private void InitEnemy()
        {
            SpawEnemy enemyTemp = null;
            foreach (Transform trans in transform)
            {
                enemyTemp = trans.GetOrAddComponent<SpawEnemy>();
                enemyTemp.Init();
                inactiveEnemies.Add(enemyTemp);
            }
        }

        private void Spaw()
        {

        }

        private int GetSpawNum()
        {
            return ModelManager.Single.SpawEnemyModel.SpawLimitNum - activeEnemies.Count;
        }
    }
}
