using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface IInputService
    {
        void Input(InputButton button, InputState state);
    }

    /// <summary>
    /// ������� 
    /// </summary>
    public class EntitasInputService : IInputService, IInitService
    {
        private Contexts contexts;
        public void Init(Contexts contexts)
        {
            this.contexts = contexts;
            contexts.service.SetGameServiceEntitasInputService(this);
            this.contexts.input.SetGameInputButton(InputButton.NONE,InputState.NONE);
        }

        public void Update()
        {

        }

        public int GetPriority()
        {
            return 0;
        }

        public void Input(InputButton button,InputState state)
        {
            this.contexts.input.SetGameInputButton(button, state);
        }
    }

    /// <summary>
    /// ��Unity�������������
    /// </summary>
    public class UnityInputService : IInputService,IInitService,IExecuteService,IPlayerBehaviour
    {
        private IInputService entitasInputService;
        private bool isPress;

        public void Init(Contexts contexts)
        {
            entitasInputService = contexts.service.gameServiceEntitasInputService.EntitasInputService;
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
            InputPress(KeyCode.W, InputButton.FORWARD);
        }

        public void Back()
        {
            InputPress(KeyCode.S, InputButton.BACK);
        }

        public void Left()
        {
            InputPress(KeyCode.A, InputButton.LEFT);
        }

        public void Right()
        {
            InputPress(KeyCode.D, InputButton.RIGHT);
        }

        public void AttackO()
        {
            InputDown(KeyCode.K, InputButton.ATTACK_O);
        }

        public void AttackX()
        {
            InputDown(KeyCode.L, InputButton.ATTACK_X);
        }

        public void Idle()
        {
            if(!isPress)
            {
                InputDown(KeyCode.None, InputButton.NONE);
            }
        }

        public void InputDown(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
            {
                Input(button, InputState.DOWN);
                isPress = true;
            }
        }
        public void InputUp(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
            {
                Input(button, InputState.UP);
            }
        }

        public void InputPress(KeyCode code,InputButton button)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.L))
            {
                Input(button, InputState.PRESS);
                isPress = true;
            }
        }

        public void Input(InputButton button, InputState state)
        {
            entitasInputService.Input(button, state);
        }

        public int GetPriority()
        {
            return 1;
        }
    }

}
