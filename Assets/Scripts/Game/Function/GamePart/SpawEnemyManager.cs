using UnityEngine;
using Util;

namespace Game.GamePart
{
    public class SpawEnemyManager:MonoBehaviour     
    {
        public  void Init()         
        {
            SpawEnemy enemyTemp = null;
            foreach (Transform trans in transform)
            {
               enemyTemp = trans.GetOrAddComponent<SpawEnemy>();
               enemyTemp.Init();
            }
        }
    }
}
