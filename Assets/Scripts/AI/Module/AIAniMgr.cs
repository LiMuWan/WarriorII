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
            string name = aniName.ToString();
            if (_ani[name] != null)
            {
                _ani.CrossFade(aniName.ToString());
            }
            else
            {
                GetAniCtrl(name).Play();
            }
        }

        private AniController GetAniCtrl(string name)
        {
            if (!_specialAniDic.ContainsKey(name))
            {
                return _specialAniDic[name] = InitSpecial(Path.ENEMY_PATH + name);
            }
            else
            {
                return _specialAniDic[name];
            }
        }

        private AnimationClip GetAniClip(string name)
        {
            if(_ani[name] != null)
            {
                return _ani[name].clip;
            }
            else
            {
                return GetAniCtrl(name).GetAniClip();
            }
        }

        public float GetAniLength<T>(T aniName)
        {
            string name = aniName.ToString();
            if (_ani[name] != null)
            {
                return _ani[aniName.ToString()].length;
            }
            else
            {
                return GetAniClip(name).length;
            }
        }

        private AniController InitSpecial(string path)
        {
            GameObject dead = LoadManager.Single.Load<GameObject>(path, "");
            AniController aniCtrl = null;
            if (dead != null)
            {
                aniCtrl = dead.AddComponent<AniController>();
                aniCtrl.Init(_self.position);
            }
            else
            {
                DebugMsg.LogError("该路径的动画资源未找到 : " + path);
            }
            return aniCtrl;
        }
    }
}
