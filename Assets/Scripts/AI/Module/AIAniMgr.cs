using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AIAniMgr 
    {
        private Animation _ani;

        public AIAniMgr(object ani)
        {
            _ani = ani as Animation;
        }

        public void Play<T>(T aniName)
        {
            _ani.CrossFade(aniName.ToString());
        }

        public float GetAniLength(string aniName)
        {
            return _ani[aniName].length;
        }
    }
}
