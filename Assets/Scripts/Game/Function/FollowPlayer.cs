using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class FollowPlayer:MonoBehaviour     
    {
        private Transform player;
        private Transform playerRoot;
        private Vector3 offset;

        private void Start()
        {
           player = GameObject.FindGameObjectWithTag(Const.TagAndLayer.PLAYER).transform;
           playerRoot = player.parent;
           offset = transform.position - playerRoot.position;
        }

        private void Update()
        {
            transform.DOMove(player.position + offset, 0.2f); 
        }
    }
}
