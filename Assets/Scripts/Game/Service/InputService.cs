using UnityEngine;

namespace Game
{
    /// <summary>
    /// 输入服务接口
    /// </summary>
    public interface IInputService
    {
        void Init(Contexts contexts);

        void Update();
        void Up();
        void Down();
        void Left();
        void Right();

        /// <summary>
        /// 攻击键（按下K）
        /// </summary>
        void AttackO();
        /// <summary>
        /// 攻击键（按下L)
        /// </summary>
        void AttackX();
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

        public void AttackO()
        {
            this.contexts.input.SetGameInputButton(InputButton.ATTACK_O);
        }

        public void AttackX()
        {
            this.contexts.input.SetGameInputButton(InputButton.ATTACK_X);
        }

        public void Down()
        {
            this.contexts.input.SetGameInputButton(InputButton.DOWN);
        }

        public void Left()
        {
            this.contexts.input.SetGameInputButton(InputButton.LEFT);
        }

        public void Right()
        {
            this.contexts.input.SetGameInputButton(InputButton.RIGHT);
        }

        public void Up()
        {
            this.contexts.input.SetGameInputButton(InputButton.UP);
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
            if(Input.GetKeyDown(KeyCode.W))
            {
                Up();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Down();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Right();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AttackO();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                AttackX();
            }
        }
         
        public void AttackO()
        {
            throw new System.NotImplementedException();
        }

        public void AttackX()
        {
            throw new System.NotImplementedException();
        }

        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public void Up()
        {
            throw new System.NotImplementedException();
        }
    }

}
