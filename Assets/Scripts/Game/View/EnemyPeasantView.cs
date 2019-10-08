using System;
using BlueGOAP;
using Entitas;
using Entitas.Unity;
using Game.AI;
using Manager;

namespace Game.View
{
    public class EnemyPeasantView:ViewBase     
    {
        private IAgent<ActionEnum, GoalEnum> _ai;

        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            _ai = new PeasantAgent((agent, map) => { OnInitGameData(agent,map); });
            EnemyData data = ModelManager.Single.EnemyDataModel.DataDic[Const.EnemyId.EnemyPeasant];
            _ai.Maps.SetGameData(GameDataKeyEnum.CONFIG, data);
        }

        private void FixedUpdate()
        {
            _ai.FrameFun();
        }

        private void OnInitGameData(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> map)
        {
            
        }
    }
}
