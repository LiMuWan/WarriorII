using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AIAniMgr 
    {
        private Animation _ani;

        public AIAniMgr(object selfTransform)
        {
            try
            {
                _ani = (selfTransform as Transform).GetComponent<Animation>();
            }
            catch (System.Exception)
            {
                Debug.LogError("为获取到当前对象的Transform组件");
            }

            if(_ani == null)
            {
                Debug.LogError("为获取到当前对象的动画组件");
            }
        }

        public void Play<T>(T aniName)
        {
            Debug.Log(aniName.ToString());
            _ani.CrossFade(aniName.ToString());
        }

        public float GetAniLength<T>(T aniName)
        {
            return _ani[aniName.ToString()].length;
        }
    }
}
