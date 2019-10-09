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
            _ai = new PeasantAgent((agent, map) => { OnInitGameData(agent,map,contexts,GetComponent<AudioSource>()); });
        }

        private void FixedUpdate()
        {
            _ai.FrameFun();
        }

        private void OnInitGameData(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps,Contexts contexts,AudioSource audioSource)
        {
            EnemyData temp = ModelManager.Single.EnemyDataModel.DataDic[Const.EnemyId.EnemyPeasant];
            EnemyData data = new EnemyData();
            data.Copy(temp);
            maps.SetGameData(GameDataKeyEnum.CONFIG, data);
            maps.SetGameData(GameDataKeyEnum.SELF_TRANS, transform);
            Transform player = (contexts.game.gamePlayer.PlayerView as ViewBase).transform;
            maps.SetGameData(GameDataKeyEnum.ENEMY_TRANS, player);

            maps.SetGameData(GameDataKeyEnum.AUDIO_SOURCE, audioSource);
        }
    }
}
