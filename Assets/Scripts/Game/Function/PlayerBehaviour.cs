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
            PlayerOrientation(Vector3.zero);
        }

        public void Back()
        {
            Move(5f, Vector3.back);
            PlayerOrientation(Vector3.up * 180); 
        }

        public void Left()
        {
            Move(5f, Vector3.left);
            PlayerOrientation(Vector3.up * (-90));
        }

        public void Right()
        {
            Move(5f, Vector3.right);
            PlayerOrientation(Vector3.up * 90);
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
            playerTrans.Translate(Time.deltaTime * speed * direction, Space.World);
        }

        private void PlayerOrientation(Vector3 direction)
        {
            playerTrans.eulerAngles = direction;
        }
    }
}
