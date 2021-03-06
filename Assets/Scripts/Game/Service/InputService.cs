﻿using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 输入服务接口
    /// </summary>
    public interface IInputService
    {
        void Input(InputButton button, InputState state);
    }

    /// <summary>
    /// 输入服务 
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
            this.contexts.input.ReplaceGameInputButton(button, state);
        }
    }

    /// <summary>
    /// 与Unity交互的输入服务
    /// </summary>
    public class UnityInputService : IInputService,IInitService,IExecuteService,IPlayerBehaviour
    {
        private IInputService entitasInputService;
        private bool isPress;
        private Contexts contexts;
        private InputButtonComponent inputButtonComponent;

        public bool IsRun { get; set; }

        public bool IsAttack { get; private set; }

        public bool IsColliderWall { get; set; }

        public void Init(Contexts contexts)
        {
            this.contexts = contexts;
            inputButtonComponent = contexts.input.gameInputButton;
            entitasInputService = contexts.service.gameServiceEntitasInputService.EntitasInputService;
        }

        public void Execute()
        {
            isPress = false;
            TurnForward();
            TurnBack();
            TurnLeft();
            TurnRight();
            Idle();
            Attack(0);
        }
         
        public void TurnForward()
        {
            if(!InputDown(KeyCode.W, InputButton.FORWARD))
                InputPress(KeyCode.W, InputButton.FORWARD);
        }

        public void TurnBack()
        {
            if(!InputDown(KeyCode.S, InputButton.BACK))
                InputPress(KeyCode.S, InputButton.BACK);
        }

        public void TurnLeft()
        {
           if(!InputDown(KeyCode.A, InputButton.LEFT))
                InputPress(KeyCode.A, InputButton.LEFT);
        }

        public void TurnRight()
        {
            if(!InputDown(KeyCode.D, InputButton.RIGHT))
                InputPress(KeyCode.D, InputButton.RIGHT);
        }

        public void Attack(int skillCode)
        {
            InputDown(KeyCode.K, InputButton.ATTACK_O);
            InputDown(KeyCode.L, InputButton.ATTACK_X);
        }

        public void Idle()
        {
            //这四个键都没有松 ，并且是持续按下的时候
            if(!isPress && inputButtonComponent.InputButton != InputButton.NONE && inputButtonComponent.InputState !=
                InputState.NONE)
            {
                entitasInputService.Input(InputButton.NONE, InputState.NONE);   
            }
        }

        public bool InputDown(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKeyDown(code))
            {
                Input(button, InputState.DOWN);
                isPress = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InputUp(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKeyUp(code))
            {
                Input(button, InputState.UP);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InputPress(KeyCode code,InputButton button)
        {
            if (UnityEngine.Input.GetKey(code))
            {
                Input(button, InputState.PRESS);
                isPress = true;
                return true;
            }
            else
            {
                return false;
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

        public void Move()
        {
            
        }
    }

}
