﻿using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public interface IMap<TAction,TGoal>
    {
        IActionHandler<TAction> GetActionHandler(TAction actionLabel);

        IGoal<TGoal> GetGoal(TGoal goalLabel);
    }

    public abstract class MapBase<TAction,TGoal> : IMap<TAction, TGoal>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;
        private Dictionary<TGoal, IGoal<TGoal>> _goalDic;

        public MapBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _goalDic = new Dictionary<TGoal, IGoal<TGoal>>();
            InitActionMap();
            InitGoalMap();
        }

        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            IActionHandler<TAction> handler = null;
            _actionHandlerDic.TryGetValue(actionLabel, out handler);

            if (handler == null)
                DebugMsg.LogError("当前映射中未找到对应IActionHandler,标签名称为：" + actionLabel);

            return handler;
        }

        public IGoal<TGoal> GetGoal(TGoal goalLabel)
        {
            IGoal<TGoal> goal = null;
            _goalDic.TryGetValue(goalLabel, out goal);

            if (goal == null)
                DebugMsg.LogError("当前映射中未找到对应IGoal,标签名称为： " + goalLabel);

            return goal;
        }

        protected abstract void InitActionMap();

        protected abstract void InitGoalMap();

        protected void AddAction(IActionHandler<TAction> handler)
        {
            if(!_actionHandlerDic.ContainsKey(handler.Label))
            {
                _actionHandlerDic.Add(handler.Label, handler);
            }
            else
            {
                DebugMsg.LogError("发现具有重复标签的Handler，标签为：" + handler.Label);
            }
        }

        protected void AddGoal(IGoal<TGoal> goal)
        {
            if(!_goalDic.ContainsKey(goal.Lable))
            {
                _goalDic.Add(goal.Lable,goal);
            }
            else
            {
                DebugMsg.LogError("发现具有重复标签的Goal,标签为 ： " + goal.Lable);
            }
        }
    }
}
