using System.Collections.Generic;
using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class AIModelMgrBase<T>     
    {
        private Dictionary<T, IModel> _modelDic;

        public AIModelMgrBase()
        {
            _modelDic = new Dictionary<T, IModel>();
            InitModels();
        }

        public IModel GetModel(T label)
        {
            if(!_modelDic.ContainsKey(label))
            {
                DebugMsg.LogError("缓存中未找到，未对该Model对象进行初始化，标签 : " + label);
                return null;
            }
            else
            {
                return _modelDic[label];
            }
        }

        protected abstract void InitModels();

        protected void AddModel(T label,IModel model)
        {
            if (!_modelDic.ContainsKey(label))
            {
                _modelDic.Add(label, model);
            }
            else
            {
                DebugMsg.LogError("缓存中未找到，未对该Model对象进行初始化，标签 : " + label);
            }
        }
    }

    public class AIModelMgr : AIModelMgrBase<ActionEnum>
    {
        public AIModelMgr() : base()
        {

        }

        protected override void InitModels()
        {
            AddModel(ActionEnum.ATTACK, new AttackModel());
        }
    }
}
