using Game.Interface;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 玩家基础行为
    /// </summary>
    public class PlayerBehaviour : IPlayerBehaviour
    {
        private Transform playerTrans;
        private PlayerDataModel model;
        private bool isAttack;

        public bool IsRun { get; set; }

        public PlayerBehaviour(Transform player,PlayerDataModel model)
        {
            playerTrans = player;
            this.model = model;
            isAttack = false;
        }

        public void TurnForward()
        {
            if (isAttack)
                return;
            PlayerOrientation(Vector3.zero);
        }

        public void TurnBack()
        {
            if (isAttack)
                return;
            PlayerOrientation(Vector3.up * 180); 
        }

        public void TurnLeft()
        {
            if (isAttack)
                return;
            PlayerOrientation(Vector3.up * (-90));
        }

        public void TurnRight()
        {
            if (isAttack)
                return;
            PlayerOrientation(Vector3.up * 90);
        }

        public void Attack(int skillCode)
        {
            isAttack = true;
        }

        public void Move()
        {
            playerTrans.Translate(Time.deltaTime * model.Speed * Vector3.forward, Space.Self);
        }

        private void PlayerOrientation(Vector3 direction)
        {
            playerTrans.eulerAngles = direction;
        }

        public void Idle()
        {
            isAttack = false;
        }
    }
}
