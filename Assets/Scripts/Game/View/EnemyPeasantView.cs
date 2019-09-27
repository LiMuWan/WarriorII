using System;
using BlueGOAP;
using Entitas;
using Entitas.Unity;
using Game.AI;

namespace Game.View
{
    public class EnemyPeasantView:ViewBase     
    {
        private IAgent<ActionEnum, GoalEnum> _ai;

        public  override void Init(Contexts contexts,IEntity entity)        
        {
            base.Init(contexts,entity);
            _ai = new PeasantAgent((agent, map) => { OnInitGameData(agent,map); });
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
