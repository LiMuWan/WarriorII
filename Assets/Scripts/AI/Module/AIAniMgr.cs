using System.Collections.Generic;
using BlueGOAP;
using Manager;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AIAniMgr 
    {
        private Animation _ani;
        private Transform _self;
        private Dictionary<string, AniController> _specialAniDic;

        public AIAniMgr(object selfTransform)
        {
            try
            {
                _specialAniDic = new Dictionary<string, AniController>();
                _self = selfTransform as Transform;
                _ani = _self.GetComponent<Animation>();
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

        private AnimationClip GetAniClip(string name)
        {
            if(_ani[name] != null)
            {
                return _ani[name].clip;
            }
            else
            {
                if (_specialAniDic.ContainsKey(name))
                {
                    return _specialAniDic[name].GetAniClip();
                }
                else
                {
                   AniController aniCtrl = InitSpecialDead(Path.ENEMY_PATH + name);
                    _specialAniDic.Add(name, aniCtrl);
                    return aniCtrl.GetAniClip();
                }
            }
        }

        public float GetAniLength<T>(T aniName)
        {
            return _ani[aniName.ToString()].length;
        }

        private AniController InitSpecialDead(string path)
        {
            GameObject dead = LoadManager.Single.Load<GameObject>(path, "");
            AniController aniCtrl = null;
            if (dead != null)
            {
                aniCtrl = dead.AddComponent<AniController>();
                Transform selfTrans = _self as Transform;
                aniCtrl.Init(selfTrans.position);

                GameObject.Destroy(selfTrans.gameObject);
            }
            else
            {
                DebugMsg.LogError("该路径的动画资源未找到 : " + path);
            }
            return aniCtrl;
        }
    }
}
