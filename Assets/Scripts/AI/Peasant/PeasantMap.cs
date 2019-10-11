﻿using UnityEngine;
using BlueGOAP;
using System;

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
            AddAction<InjureHandler, InjureAction>();
            AddAction<DeadHandler, DeadAction>();
            AddAction<MoveHandler, MoveAction>();
            AddAction<MoveBackwardHandler, MoveBackwardAction>();

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
        }
    }
}
