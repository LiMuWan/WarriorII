﻿using Const;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InputNullSystem:InputButtonSystemBase
    {
        public InputNullSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.NONE
                  && entity.gameInputButton.InputState == InputState.NONE;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (contexts.game.hasGamePlayer)
            {
                contexts.game.gamePlayer.PlayerAni.Idle();
            }
            contexts.service.gameServiceTimerService.TimerService.GetTimer(TimerId.MOVE_TIMER)?.Stop();
            contexts.game.gamePlayer.PlayerAni.IsRun = false;
        }
    }

    /// <summary>
    /// 向前按键响应系统
    /// </summary>
    public class InputForwardButtonSystem : InputPressButtonSystemBase
    {
        public InputForwardButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.FORWARD;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Forward();
            contexts.game.gamePlayer.PlayerAni.Forward();
        }
    }

    /// <summary>
    ///向后按键响应系统
    /// </summary>
    public class InputBackButtonSystem : InputPressButtonSystemBase
    {
        public InputBackButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.BACK;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Back();
            contexts.game.gamePlayer.PlayerAni.Back();
        }
    }

    /// <summary>
    ///向左按键响应系统
    /// </summary>
    public class InputLeftButtonSystem : InputPressButtonSystemBase
    {
        public InputLeftButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.LEFT;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Left();
            contexts.game.gamePlayer.PlayerAni.Left();
        }
    }

    /// <summary>
    ///向右按键响应系统
    /// </summary>
    public class InputRightButtonSystem : InputPressButtonSystemBase
    {
        public InputRightButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.RIGHT;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Right();
            contexts.game.gamePlayer.PlayerAni.Right();
        }
    }

    /// <summary>
    ///移动按键响应系统
    /// </summary>
    public class InputMoveButtonSystem : InputButtonSystemBase
    {
        public InputMoveButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.FORWARD
                || entity.gameInputButton.InputButton == InputButton.BACK
                || entity.gameInputButton.InputButton == InputButton.LEFT
                || entity.gameInputButton.InputButton == InputButton.RIGHT;
        }        

        protected override void Execute(List<InputEntity> entities)
        {
            var timerService = contexts.service.gameServiceTimerService.TimerService;
            var timer = timerService.CreateTimer(TimerId.MOVE_TIMER, 1, true);
            if (timer != null)
            {
                timer.AddCompleteListener
                 (
                     () => contexts.game.gamePlayer.PlayerAni.IsRun = true
                 ) ;
            }
        }
    }

    /// <summary>
    ///按键J响应系统
    /// </summary>
    public class InputAttackOButtonSystem : InputDownButtonSystemBase
    {
        public InputAttackOButtonSystem(Contexts contexts) : base(contexts)
        {

        }
        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.ATTACK_O;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.service.gameServiceLogService.LogService.Log("attack o");
        }
    }

    /// <summary>
    ///按键K响应系统
    /// </summary>
    public class InputAttackXButtonSystem : InputDownButtonSystemBase
    {
        public InputAttackXButtonSystem(Contexts contexts) : base(contexts)
        {

        }
        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.ATTACK_X;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.service.gameServiceLogService.LogService.Log("attack x");
        }
    }
}
