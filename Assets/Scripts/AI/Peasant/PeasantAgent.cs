using UnityEngine;
using BlueGOAP;
using System;
using Game.AI.ViewEffect;
using Const;

namespace Game.AI
{
    public class PeasantAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public override bool IsAgentOver { get; }

        private AIViewEffectMgr _viewMgr;

        public AIViewEffectMgr AIViewEffectMgr(IMaps<ActionEnum, GoalEnum> maps)
        {
            if (_viewMgr == null)
            {
                object audioSource = maps.GetGameData(GameDataKeyEnum.AUDIO_SOURCE);
                object selfTrans = maps.GetGameData(GameDataKeyEnum.SELF_TRANS);
              
                _viewMgr = new AIViewEffectMgr(EnemyId.EnemyPeasant.ToString(), audioSource, selfTrans);
            }
            return _viewMgr;
        }

        public PeasantAgent(Action<IAgent<ActionEnum, GoalEnum>, IMaps<ActionEnum, GoalEnum>> onInitGameData) : base(onInitGameData)
        {
            InitViewMgr();
        }

        protected override IState InitAgentState()
        {
            State<StateKeyEnum> state = new State<StateKeyEnum>();

            foreach (StateKeyEnum key in Enum.GetValues(typeof(StateKeyEnum)))
            {
                state.Set(key, false);
            }

            return state;
        }

        protected override DebugMsgBase InitDebugMsg()
        {
            return new AIDebug();
        }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            return new PeasantActMgr(this);
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            return new PeasantGoalMgr(this);
        }

        protected override IMaps<ActionEnum, GoalEnum> InitMaps()
        {
            return new PeasantMap(this,_onInitGameData);
        }

        protected override ITriggerManager InitTriggerManager()
        {
            return new PeasantTriggerMgr(this);
        }

        private void InitViewMgr()
        {
            PeasantActMgr actMgr = ActionManager as PeasantActMgr;
            actMgr.AddExecuteNewStateListener(_viewMgr.ExecuteState);
        }
    }
}
