﻿using Const;
using Game.Interface;
using UnityEngine;

namespace Game
{
    public class PlayerAni : IPlayerAni
    {
        public bool IsRun { get; set; }
        private Animator ani;

        public ICustomAniEventManager AniEventManager { get; set; }

        public PlayerAni(Animator animator,ICustomAniEventManager aniEventManager)
        {
            this.ani = animator;
            AniEventManager = aniEventManager;
        }
        public void Play(int aniIndex)
        {
            ani.SetInteger(ConstValue.PLAYER_PARA_NAME,aniIndex);
        }

        private void Play(PlayerAniIndex index)
        {
            Play((int)index);
        }       

        public void Forward()
        {
            Move();
        }

        public void Back()
        {
            Move();
        }

        public void Left()
        {
            Move();
        }

        public void Right()
        {
            Move();
        }

        public void Attack(int skillCode)
        {
            ani.SetInteger(ConstValue.PLAYER_SKILL_PARA_NAME, skillCode);
            ani.SetBool(ConstValue.IDLE_SWORD_PARA_NAME, true);
        }

        private void Move()
        {
            if (IsRun)
            {
                Play(PlayerAniIndex.RUN);
            }
            else
            {
                Play(PlayerAniIndex.WALK);
            }
            
        }

        public void Idle()
        {
            Play(PlayerAniIndex.IDLE);
        }
    }
}
