using System;
using BlueGOAP;
using Entitas;
using Entitas.Unity;
using Game.AI;
using Manager;
using UnityEngine;

namespace Game.View
{
    public class EnemyPeasantView:ViewBase     
    {
        private IAgent<ActionEnum, GoalEnum> _ai;

        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            _ai = new PeasantAgent((agent, map) => { OnInitGameData(agent,map); });
            EnemyData temp = ModelManager.Single.EnemyDataModel.DataDic[Const.EnemyId.EnemyPeasant];
            EnemyData data = new EnemyData();
            data.Copy(temp);
            _ai.Maps.SetGameData(GameDataKeyEnum.CONFIG, data);
            _ai.Maps.SetGameData(GameDataKeyEnum.SELF_TRANS, transform);
            Transform playerTrans = contexts.game.gamePlayer.PlayerView as Transform;
            _ai.Maps.SetGameData(GameDataKeyEnum.ENEMY_TRANS, playerTrans);
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
