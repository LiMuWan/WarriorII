using Const;
using UnityEngine;

namespace Game
{
    public class PlayerAni : IPlayerAni
    {
        private Animator ani;

        public PlayerAni(Animator animator)
        {
            this.ani = animator;
        }
        public void Play(int aniIndex)
        {
            ani.Play(aniIndex);
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

        public void AttackO()
        {
                 
        }

        public void AttackX()
        {
           
        }

        private void Move()
        {
            Play(PlayerAniIndex.WALK);
        }
    }
}
