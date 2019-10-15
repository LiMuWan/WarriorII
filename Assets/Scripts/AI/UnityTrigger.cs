using System;
using System.Threading.Tasks;
using Const;
using UnityEngine;


namespace Game.AI.ViewEffect
{
    public class UnityTrigger : MonoBehaviour
    {
        private Action<Collider> _colliderAction;

        private void Start()
        {
            Test();
        }

        private async void Test()
        {
            CharacterController controller = GetComponent<CharacterController>();
            Vector3 center = controller.center;

            //上方向
            Collider collider = GetCollider(center,20);
            await Task.Delay(TimeSpan.FromSeconds(1));
            //下方向
            collider = GetCollider(center, 160);
            await Task.Delay(TimeSpan.FromSeconds(1));
            //左方向
            collider = GetCollider(center, -70);
            await Task.Delay(TimeSpan.FromSeconds(1));
            //右方向
            collider = GetCollider(center, 70);
            await Task.Delay(TimeSpan.FromSeconds(1));
            _colliderAction(collider);
        }

        private Collider GetCollider(Vector3 center,float degress)
        {
            GameObject go = new GameObject();
            go.tag = TagAndLayer.WEAPON_TAG;
            Collider collider = go.AddComponent<BoxCollider>();
            collider.transform.position = center + new Vector3(Mathf.Sin(Mathf.Deg2Rad * degress), Mathf.Cos(Mathf.Deg2Rad * degress), 0);
            Vector3 direction = (collider.transform.position - center).normalized;
            Debug.Log("---------与上方向的角度：" + Vector3.Angle(Vector3.up, direction));
            return collider;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_colliderAction != null)
                _colliderAction(other);
        }

        public void AddColliderListener(Action<Collider> colliderAction)
        {
            _colliderAction += colliderAction;
        }
    }
}