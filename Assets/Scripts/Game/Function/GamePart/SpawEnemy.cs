using System;
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

        }
    }
}
