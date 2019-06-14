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
            return entity.gameInputButton.InputButton == InputButton.NONE;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (contexts.game.hasGamePlayer)
            {
                contexts.game.gamePlayer.PlayerAni.Idle();
            }
        }
    }

    /// <summary>
    /// ��ǰ������Ӧϵͳ
    /// </summary>
    public class InputForwardButtonSystem : InputButtonSystemBase
    {
        public InputForwardButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.UP;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Forward();
            contexts.game.gamePlayer.PlayerAni.Forward();
        }
    }

    /// <summary>
    ///��󰴼���Ӧϵͳ
    /// </summary>
    public class InputBackButtonSystem : InputButtonSystemBase
    {
        public InputBackButtonSystem(Contexts contexts) : base(contexts)
        {

        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.DOWN;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gamePlayer.PlayerBehaviour.Back();
            contexts.game.gamePlayer.PlayerAni.Back();
        }
    }

    /// <summary>
    ///���󰴼���Ӧϵͳ
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
            contexts.game.gamePlayer.PlayerBehaviour.Left();
            contexts.game.gamePlayer.PlayerAni.Left();
        }
    }

    /// <summary>
    ///���Ұ�����Ӧϵͳ
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
            contexts.game.gamePlayer.PlayerBehaviour.Right();
            contexts.game.gamePlayer.PlayerAni.Right();
        }
    }

    /// <summary>
    ///����J��Ӧϵͳ
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
            contexts.game.gameComponentLogService.LogService.Log("attack o");
        }
    }

    /// <summary>
    ///����K��Ӧϵͳ
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
            contexts.game.gameComponentLogService.LogService.Log("attack x");
        }
    }
}
