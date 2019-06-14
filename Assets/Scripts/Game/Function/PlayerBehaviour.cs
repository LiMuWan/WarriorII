using Game.Interface;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ��һ�����Ϊ
    /// </summary>
    public class PlayerBehaviour : IPlayerBehaviour
    {
        private Transform playerTrans;
        private PlayerDataModel model;
        public PlayerBehaviour(Transform player,PlayerDataModel model)
        {
            playerTrans = player;
            this.model = model;
        }

        public void Forward()
        {
            Move(Vector3.forward);
            PlayerOrientation(Vector3.zero);
        }

        public void Back()
        {
            Move(Vector3.back);
            PlayerOrientation(Vector3.up * 180); 
        }

        public void Left()
        {
            Move(Vector3.left);
            PlayerOrientation(Vector3.up * (-90));
        }

        public void Right()
        {
            Move(Vector3.right);
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

        private void Move(Vector3 direction)
        {
            playerTrans.Translate(Time.deltaTime * model.Speed * direction, Space.World);
        }

        private void PlayerOrientation(Vector3 direction)
        {
            playerTrans.eulerAngles = direction;
        }

        public void Idle()
        {
            
        }
    }
}
