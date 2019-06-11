using UnityEngine;

namespace Game
{
    /// <summary>
    /// 玩家基础行为
    /// </summary>
    public class PlayerBehaviour : IPlayerBehaviour
    {
        private Transform playerTrans;
        public PlayerBehaviour(Transform player)
        {
            playerTrans = player;
        }

        public void Forward()
        {
            Move(5f, Vector3.forward);
        }

        public void Back()
        {
            Move(5f, Vector3.back);
        }

        public void Left()
        {
            Move(5f, Vector3.left);
        }

        public void Right()
        {
            Move(5f, Vector3.right);
        }
        public void AttackO()
        {
            throw new System.NotImplementedException();
        }

        public void AttackX()
        {
            throw new System.NotImplementedException();
        }

        private void Move(float speed,Vector3 direction)
        {
            playerTrans.Translate(Time.deltaTime * speed * direction, Space.Self);
        }
    }
}
