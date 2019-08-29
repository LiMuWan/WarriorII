using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class FollowPlayer:MonoBehaviour     
    {
        private Transform player;
        private Transform playerRoot;
        private Vector3 offset;
        private Vector3 lastPos;
        private bool isMoving;
        private float rotateValue;
        private Vector3 defaultEul;
        private float rotateDuration;

        private void Start()
        {
           defaultEul = transform.eulerAngles;
           rotateValue = 2;
           rotateDuration = 0.8f;
           isMoving = false;
           lastPos = transform.position;
           player = GameObject.FindGameObjectWithTag(Const.TagAndLayer.PLAYER).transform;
           playerRoot = player.parent;
           offset = transform.position - playerRoot.position;
        }

        private void Update()
        {
            if(Vector3.Distance(transform.position,lastPos) < 0.01f && isMoving)
            {
                //移动结束
                isMoving = false;
                transform.DORotate(defaultEul, rotateDuration);
            }
            else if(Vector3.Distance(transform.position, lastPos) >= 0.01f && !isMoving)
            {
                //移动开始
                isMoving = true;
                int directionX = GetXDirection();
                int directionZ = GetZDirection();
                transform.DORotate(defaultEul + new Vector3(rotateValue * directionZ, 0 , rotateValue * directionX), rotateDuration);
            }
            else
            {
                //移动中
                transform.DOMove(player.position + offset, 0.4f);
            }
            lastPos = transform.position;
        }

        private int GetXDirection()
        {
            if (transform.position.x == lastPos.x)
                return 0;
            return transform.position.x > lastPos.x ? -1 : 1;
        }

        private int GetZDirection()
        {
            if (transform.position.z == lastPos.z)
                return 0;
            return transform.position.z > lastPos.z ? 1 : -1;
        }
    }
}
