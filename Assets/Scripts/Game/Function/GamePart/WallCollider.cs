using UnityEngine;

namespace Game.GamePart
{
    public class WallCollider:MonoBehaviour     
    {
        private Collider collider;

        public void Init(Collider collider)
        {
            this.collider = collider;
        }

        public void SetWallState(bool isOpen)
        {
            collider.enabled = !isOpen;
        }
    }
}
