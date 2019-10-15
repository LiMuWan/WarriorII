using UnityEngine;
using BlueGOAP;
using System;
using System.Collections.Generic;

namespace Game.AI
{
    public class PeasantMap : MapsBase<ActionEnum, GoalEnum>
    {
        public PeasantMap(IAgent<ActionEnum, GoalEnum> agent, Action<IAgent<ActionEnum, GoalEnum>, IMaps<ActionEnum, GoalEnum>> onInitGameData) : base(agent, onInitGameData)
        {

        }

        protected override void InitActinMaps()
        {
            //不可叠加动作状态
            AddAction<IdleHandler, IdleAction>();
            AddAction<IdleSwordHandler, IdleSwordAction>();
            AddAction<AttackHandler, AttackAction>();
            AddAction<InjureUpHandler, InjureUpAction>();
            AddAction<InjureDownHandler, InjureDownAction>();
            AddAction<InjureLeftHandler, InjureLeftAction>();
            AddAction<InjureRightHandler, InjureRightAction>();
            AddAction<DeadHandler, DeadAction>();
            AddAction<MoveHandler, MoveAction>();
            AddAction<MoveBackwardHandler, MoveBackwardAction>();
            AddAction<EnterAlertHandler, EnterAlertAction>();
            AddAction<ExitAlertHandler, ExitAlertAction>();

            //可叠加动作状态
            AddAction<AlertStateHandler, AlertStateAction>();
        }

        protected override void InitGoalMaps()
        {
            AddGoal<AttackGoal>();
            AddGoal<IdleSwordGoal>();
            AddGoal<DeadGoal>();
            AddGoal<InjureGoal>();
        }

        protected override void InitGameData(Action<IAgent<ActionEnum, GoalEnum>, IMaps<ActionEnum, GoalEnum>> onInitGameData)
        {
            base.InitGameData(onInitGameData);
            SetGameData(GameDataKeyEnum.INJURE_COLLECT_DATA, new Dictionary<ActionEnum, bool>());
        }
    }
}
