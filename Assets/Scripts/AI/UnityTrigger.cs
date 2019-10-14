using System;
using UnityEngine;


namespace Game.AI.ViewEffect
{
    public class UnityTrigger : MonoBehaviour
    {
        private Action<Collider> _colliderAction;

        private void OnTriggerEnter(Collider other)
        {
            if (_colliderAction != null)
                _colliderAction(other);
        }

        public void AddColliderListener(Action<Collider> colliderAction)
        {
            _colliderAction = colliderAction;
        }
    }
}