using UnityEngine;

namespace Game
{
    public class IgnoreForce:MonoBehaviour     
    {
        private Rigidbody rigidbody;

        private  void Start()         
        {
            rigidbody = this.GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
