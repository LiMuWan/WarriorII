using Const;
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
                contexts.game.gamePlayer.PlayerBehaviour.Idle();
                contexts.game.gamePlayer.PlayerAni.IsRun = false;
            }
            contexts.service.gameServiceTimerService.TimerService.GetTimer(TimerId.MOVE_TIMER)?.Stop(true);
            
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
            contexts.game.gamePlayer.PlayerBehaviour.TurnForward();
            contexts.game.gamePlayer.PlayerAni.Move();
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
            contexts.game.gamePlayer.PlayerBehaviour.TurnBack();
            contexts.game.gamePlayer.PlayerAni.Move();
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
            contexts.game.gamePlayer.PlayerBehaviour.TurnLeft();
            contexts.game.gamePlayer.PlayerAni.Move();
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
            contexts.game.gamePlayer.PlayerBehaviour.TurnRight();
            contexts.game.gamePlayer.PlayerAni.Move();
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
}
