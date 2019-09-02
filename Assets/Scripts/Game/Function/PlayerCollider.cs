using Const;
using UnityEngine;

namespace Game
{
    public class PlayerCollider:MonoBehaviour     
    {
        private  void Start()         
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if(string.Equals(other.tag,TagAndLayer.WALL_TAG))
            {
                Contexts.sharedInstance.game.gamePlayer.PlayerBehaviour.IsColliderWall = true;
            }
        }
    }
}
