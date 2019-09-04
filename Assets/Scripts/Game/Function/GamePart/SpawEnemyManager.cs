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
            int index = 1;
            foreach (Transform trans in transform)
            {
                enemyTemp = trans.GetOrAddComponent<SpawEnemy>();
                enemyTemp.Init(index,RemoveEnemyCallBack);
                inactiveEnemies.Add(enemyTemp);
                index++;
            }
        }

        private void RemoveEnemyCallBack(SpawEnemy enemy)
        {
            activeEnemies.Remove(enemy);
            Spaw();
        }

        public void Spaw()
        {
            int count = GetSpawNum();
            SpawEnemy enemyTemp = null;

            HashSet<SpawEnemy>.Enumerator temp = inactiveEnemies.GetEnumerator();

            for (int i = 0; i < count; i++)
            {
                if (temp.MoveNext())
                {
                    enemyTemp = temp.Current;
                    activeEnemies.Add(enemyTemp);  
                    enemyTemp.Spaw();
                }
            }

            foreach (SpawEnemy enemy in activeEnemies)
            {
                inactiveEnemies.Remove(enemyTemp);
            }
        }

        private int GetSpawNum()
        {
            return ModelManager.Single.EnemyModel.SpawLimitNum - activeEnemies.Count;
        }
    }
}
