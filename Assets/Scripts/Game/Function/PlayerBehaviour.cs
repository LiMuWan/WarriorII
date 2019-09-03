using DG.Tweening;
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
        public bool IsAttack { get; private set; }
        private Vector3 faceDirection;
        private bool isFaceDirectionChange;
        public bool IsRun { get; set; }
        public bool IsColliderWall { get; set; }

        public PlayerBehaviour(Transform player, PlayerDataModel model)
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
            SetDirectionData(Vector3.zero);
        }

        public void TurnBack()
        {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * 180);
        }

        public void TurnLeft()
        {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * (-90));
        }

        public void TurnRight()
        {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * 90);
        }

        public void Attack(int skillCode)
        {
            IsAttack = true;
        }

        private void SetDirectionData(Vector3 direction)
        {
            if(faceDirection != direction)
            {
                faceDirection = direction;
                isFaceDirectionChange = true;
            }
        }

        public void Move()
        {
            if(isFaceDirectionChange)
            {
                IsColliderWall = false;
            }

            RotateFace();

            PlayerMove();
        }

        private void PlayerMove()
        {
            if (IsColliderWall)
                return;

            playerTrans.Translate(Time.deltaTime * model.Speed * Vector3.forward, Space.Self);
        }

        private void RotateFace()
        {
            if (isFaceDirectionChange)
            {
                isFaceDirectionChange = false;
                PlayerOrientation(faceDirection);
            }
        }

        private void PlayerOrientation(Vector3 direction)
        {
            float rotateYValue = Mathf.Abs((playerTrans.eulerAngles - direction).y);
            if (rotateYValue == 90)
            {
                playerTrans.DORotate(direction, 0.3f);
            }
            else
            {
                playerTrans.eulerAngles = direction;
            }
        }

        public void Idle()
        {
            IsAttack = false;
        }
    }
}
