using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 向上按键响应系统
    /// </summary>
    public class InputUpButtonSystem : InputButtonSystemBase
    {
        public InputUpButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.UP;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameLogService.LogService.Log("Up");
            contexts.game.gamePlayer.PlayerBehaviour.Forward();
        }
    }

    /// <summary>
    ///向下按键响应系统
    /// </summary>
    public class InputDownButtonSystem : InputButtonSystemBase
    {
        public InputDownButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.DOWN;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameLogService.LogService.Log("Down");
        }
    }

    /// <summary>
    ///向左按键响应系统
    /// </summary>
    public class InputLeftButtonSystem : InputButtonSystemBase
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
            contexts.game.gameLogService.LogService.Log("Left");
        }
    }

    /// <summary>
    ///向右按键响应系统
    /// </summary>
    public class InputRightButtonSystem : InputButtonSystemBase
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
            contexts.game.gameLogService.LogService.Log("Right");
        }
    }

    /// <summary>
    ///按键J响应系统
    /// </summary>
    public class InputAttackOButtonSystem : InputButtonSystemBase
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
            contexts.game.gameLogService.LogService.Log("attack o");
        }
    }

    /// <summary>
    ///按键K响应系统
    /// </summary>
    public class InputAttackXButtonSystem : InputButtonSystemBase
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
            contexts.game.gameLogService.LogService.Log("attack x");
        }
    }
}
