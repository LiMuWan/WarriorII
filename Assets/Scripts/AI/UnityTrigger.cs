using System;
using System.Threading.Tasks;
using Const;
using Game.View;
using UnityEngine;


namespace Game.AI.ViewEffect
{
    public class UnityTrigger : MonoBehaviour
    {
        private Action<Collider> _colliderAction;

#if TEST
        private void Start()
        {
            Test();
        }

        private async void Test()
        {
            CharacterController controller = GetComponent<CharacterController>();
            Vector3 center = controller.center;
            await Task.Delay(TimeSpan.FromSeconds(1));
            transform.GetComponent<EnemyPeasantView>().AI.Maps.SetGameData(GameDataKeyEnum.INJURE_VALUE, 1000);
            ////上方向
            //_colliderAction(GetDirectionCollider(center,20));
            //await Task.Delay(TimeSpan.FromSeconds(1));
            ////下方向
            //_colliderAction(GetDirectionCollider(center, 160));
            //await Task.Delay(TimeSpan.FromSeconds(1));
            ////左方向
            //_colliderAction(GetDirectionCollider(center, -70));
            //await Task.Delay(TimeSpan.FromSeconds(1));
            ////右方向
            //_colliderAction(GetDirectionCollider(center, 70));
            //await Task.Delay(TimeSpan.FromSeconds(1));

            //普通死亡
            _colliderAction(GetPosCollider(new Vector3(center.x, center.y + controller.height * 0.5f, center.z)));
           
            ////头部
            //_colliderAction(GetPosCollider(new Vector3(center.x,center.y + controller.height * 0.5f ,center.z)));
            //await Task.Delay(TimeSpan.FromSeconds(2));
            ////身体
            //_colliderAction(GetPosCollider(new Vector3(center.x, center.y, center.z)));
            //await Task.Delay(TimeSpan.FromSeconds(2));
            ////腿
            //_colliderAction(GetPosCollider(new Vector3(center.x, center.y - controller.height * 0.5f, center.z)));
            //await Task.Delay(TimeSpan.FromSeconds(2));
        }

        private Collider GetDirectionCollider(Vector3 center,float degress)
        {
            GameObject go = new GameObject();
            go.tag = TagAndLayer.WEAPON_TAG;
            Collider collider = go.AddComponent<BoxCollider>();
            collider.transform.localPosition = center + new Vector3(Mathf.Sin(Mathf.Deg2Rad * degress), Mathf.Cos(Mathf.Deg2Rad * degress), 0);
            Vector3 direction = (collider.transform.position - center).normalized;
            Debug.Log("---------与上方向的角度：" + Vector3.Angle(Vector3.up, direction));
            return collider;
        }

        private Collider GetPosCollider(Vector3 pos)
        {
            GameObject go = new GameObject();
            go.tag = TagAndLayer.WEAPON_TAG;
            Collider collider = go.AddComponent<BoxCollider>();
            collider.transform.localPosition = pos;
            return collider;
        }
#endif

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