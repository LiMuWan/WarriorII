using Const;
using UnityEngine;

namespace Game
{
    public class PlayerCollider:MonoBehaviour     
    {

        private void OnTriggerEnter(Collider other)
        {
            if(string.Equals(other.tag,TagAndLayer.WALL_TAG))
            {
                Contexts.sharedInstance.game.gamePlayer.PlayerBehaviour.IsColliderWall = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(string.Equals(other.tag, TagAndLayer.WALL_TAG))
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position,transform.forward,out hit,0.5f))
                {
                    var hasWall = hit.transform.tag == TagAndLayer.WALL_TAG;
                    Contexts.sharedInstance.game.gamePlayer.PlayerBehaviour.IsColliderWall = hasWall;
                }
                else
                {
                    Contexts.sharedInstance.game.gamePlayer.PlayerBehaviour.IsColliderWall = false;
                }
            }
            
        }
    }
}
