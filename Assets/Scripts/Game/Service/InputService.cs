using UnityEngine;

namespace Game
{
    /// <summary>
    /// 输入服务接口
    /// </summary>
    public interface IInputService:IPlayerBehaviour
    {
        void Init(Contexts contexts);

        void Update();
    }

    /// <summary>
    /// 输入服务 
    /// </summary>
    public class EntitasInputService : IInputService
    {
        private Contexts contexts;
        public void Init(Contexts contexts)
        {
            this.contexts = contexts;
            this.contexts.input.SetGameInputButton(InputButton.NONE);
        }

        public void Update()
        {

        }

        public void Forward()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.UP);
        }

        public void Back()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.DOWN);
        }

        public void Left()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.LEFT);
        }

        public void Right()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.RIGHT);
        }

        public void AttackO()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.ATTACK_O);
        }

        public void AttackX()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.ATTACK_X);
        }
    }

    /// <summary>
    /// 与Unity交互的输入服务
    /// </summary>
    public class UnityInputService : IInputService
    {
        private IInputService entitasInputService;

        public void Init(Contexts contexts)
        {
            entitasInputService = contexts.game.gameEntitasInputService.EntitasInputService;
        }

        public void Update()
        {

            Forward();
            Back();
            Left();
            Right();
            AttackO();
            AttackX();
        }
         
        public void Forward()
        {
            if (Input.GetKey(KeyCode.W))
            {
                entitasInputService.Forward();
            }
        }

        public void Back()
        {
         if (Input.GetKey(KeyCode.S))
            {
                entitasInputService.Back();
            }
        }

        public void Left()
        {
            if (Input.GetKey(KeyCode.A))
            {
                entitasInputService.Left();
            }
        }

        public void Right()
        {
            if (Input.GetKey(KeyCode.D))
            {
                entitasInputService.Right();
            }
        }

        public void AttackO()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                entitasInputService.AttackO();
            }
        }

        public void AttackX()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                entitasInputService.AttackX();
            }
        }
    }

}
