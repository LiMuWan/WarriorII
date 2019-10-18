using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.AI
{
    public class AniController:MonoBehaviour     
    {
        private Animation _ani;

        public  void Init(Vector3 position)
        {
            transform.position = position;
            _ani = transform.GetComponent<Animation>();
            gameObject.SetActive(false);
        }

        public AnimationClip GetAniClip()
        {
            return _ani.clip;
        }

        public async void Play()
        {
            gameObject.SetActive(true);
            _ani.Play(GetAniClip().name);

            await Task.Delay(TimeSpan.FromSeconds(GetAniClip().length));

            Destroy(gameObject);
        }
    }
}
