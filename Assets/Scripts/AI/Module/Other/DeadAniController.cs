using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.AI
{
    public class AniController:MonoBehaviour     
    {
        private Animation _ani;

        public async void Init(Vector3 position)
        {
            transform.position = position;
            _ani = transform.GetComponent<Animation>();
            _ani.Play(_ani.clip.name);

            await Task.Delay(TimeSpan.FromSeconds(_ani.clip.length));

            Destroy(gameObject);
        }

        public AnimationClip GetAniClip()
        {
            return _ani.clip;
        }
    }
}
