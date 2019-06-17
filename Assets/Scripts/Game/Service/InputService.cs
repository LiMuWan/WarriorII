using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface IInputService:IPlayerBehaviour,IInitService,IExecuteService
    {
   
    }

    /// <summary>
    /// ������� 
    /// </summary>
    public class EntitasInputService : IInputService
    {
        private Contexts contexts;
        public void Init(Contexts contexts)
        {
            this.contexts = contexts;
            contexts.game.SetGameComponentEntitasInputService(this);
            this.contexts.input.SetGameInputButton(InputButton.NONE);
        }

        public int GetPriority()
        {
            return 0;
        }

        public void Execute()
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

        public void Idle()
        {
            this.contexts.input.ReplaceGameInputButton(InputButton.NONE);
        }
    }

    /// <summary>
    /// ��Unity�������������
    /// </summary>
    public class UnityInputService : IInputService,IInitService,IExecuteService
    {
        private IInputService entitasInputService;
        private bool isPress;

        public void Init(Contexts contexts)
        {
            entitasInputService = contexts.game.gameComponentEntitasInputService.EntitasInputService;
        }

        public void Execute()
        {
            isPress = false;
            Forward();
            Back();
            Left();
            Right();
            AttackO();
            AttackX();
            Idle();
        }
         
        public void Forward()
        {
            if (Input.GetKey(KeyCode.W))
            {
                entitasInputService.Forward();
                isPress = true;
            }
        }

        public void Back()
        {
         if (Input.GetKey(KeyCode.S))
            {
                entitasInputService.Back();
                isPress = true;
            }
        }

        public void Left()
        {
            if (Input.GetKey(KeyCode.A))
            {
                entitasInputService.Left();
                isPress = true;
            }
        }

        public void Right()
        {
            if (Input.GetKey(KeyCode.D))
            {
                entitasInputService.Right();
                isPress = true;
            }
        }

        public void AttackO()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                entitasInputService.AttackO();
                isPress = true;
            }
        }

        public void AttackX()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                entitasInputService.AttackX();
                isPress = true;
            }
        }

        public void Idle()
        {
            if(!isPress)
            {
                entitasInputService.Idle();
            }
        }

        public int GetPriority()
        {
            return 1;
        }
    }

}
