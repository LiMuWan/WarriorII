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
        public bool IsAttack { get; private set;}
        private Vector3 faceDirection;
        private bool isFaceDirectionChange;
        public bool IsRun { get; set; }

        public PlayerBehaviour(Transform player,PlayerDataModel model)
        {
            playerTrans = player;
            this.model = model;
            IsAttack = false;
            faceDirection = Vector3.zero;
            isFaceDirectionChange = false;
        }

        public void TurnForward()
        {
            if (IsAttack)
                return;
            faceDirection = Vector3.zero;
            isFaceDirectionChange = true;
        }

        public void TurnBack()
        {
            if (IsAttack)
                return;
            faceDirection = Vector3.up * 180;
            isFaceDirectionChange = true;
        }

        public void TurnLeft()
        {
            if (IsAttack)
                return;
            faceDirection = Vector3.up * (-90);
            isFaceDirectionChange = true;
        }

        public void TurnRight()
        {
            if (IsAttack)
                return;
            faceDirection = Vector3.up * 90;
            isFaceDirectionChange = true;
        }

        public void Attack(int skillCode)
        {
            IsAttack = true;
        }

        public void Move()
        {
            if (isFaceDirectionChange)
            {
                isFaceDirectionChange = false;
                PlayerOrientation(faceDirection);
            }
            playerTrans.Translate(Time.deltaTime * model.Speed * Vector3.forward, Space.Self);
        }

        private void PlayerOrientation(Vector3 direction)
        {
            playerTrans.eulerAngles = direction;
        }

        public void Idle()
        {
            IsAttack = false;
        }
    }
}
