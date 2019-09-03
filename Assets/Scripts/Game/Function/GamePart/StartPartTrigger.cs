using System;
using Const;
using UnityEngine;

namespace Game
{
    public class StartPartTrigger:MonoBehaviour     
    {
        private Action startCallBack;

        public void Init(Action startCallBack)
        {
            this.startCallBack = startCallBack;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(TagAndLayer.PLAYER_TAG) && startCallBack != null)
            {
                startCallBack.Invoke();
                startCallBack = null;
            }
        }
    }
}
