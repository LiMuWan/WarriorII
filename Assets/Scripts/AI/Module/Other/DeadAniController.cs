using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.AI
{
    public class DeadAniController:MonoBehaviour     
    {
        public async void Init(Vector3 position)
        {
            transform.position = position;
            Animation ani = transform.GetComponent<Animation>();
            ani.Play(ani.clip.name);

            await Task.Delay(TimeSpan.FromSeconds(ani.clip.length));

            Destroy(gameObject);
        }
    }
}
