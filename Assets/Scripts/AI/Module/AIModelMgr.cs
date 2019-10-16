using System.Collections.Generic;
using BlueGOAP;
using Game.AI.Model;

namespace Game.AI
{
    public abstract class AIModelMgrBase<T>     
    {
        private Dictionary<T, IModel> _modelDic;

        public AIModelMgrBase()
        {
            _modelDic = new Dictionary<T, IModel>();
            InitModels();
        }

        public TModel GetModel<TModel>(T label) where TModel : class , IModel
        {
            if(!_modelDic.ContainsKey(label))
            {
                DebugMsg.LogWarning("缓存中未找到，未对该Model对象进行初始化，标签 : " + label);
                return null;
            }
            else
            {
                return _modelDic[label] as TModel;
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
            AddModel(ActionEnum.ENTER_ALERT, new EnterAlertModel());
            AddModel(ActionEnum.EXIT_ALERT, new ExitAlertModel());
            AddModel(ActionEnum.INJURE_UP, new InjureUpModel());
            AddModel(ActionEnum.INJURE_DOWN, new InjureDownModel());
            AddModel(ActionEnum.INJURE_LEFT, new InjureLeftModel());
            AddModel(ActionEnum.INJURE_RIGHT, new InjureRightModel());
            AddModel(ActionEnum.DEAD, new DeadModel());
            AddModel(ActionEnum.DEAD, new DeadModel());
            AddModel(ActionEnum.DEAD, new DeadModel());
            AddModel(ActionEnum.DEAD, new DeadModel());
        }
    }
}
