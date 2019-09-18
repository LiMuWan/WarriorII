using UnityEngine;

namespace GOAPTest
{
    public class ObjectInScene:MonoBehaviour     
    {
        public Transform Player;
        public Transform Enemy;

        public static ObjectInScene Instance { get; private set; }

        private  void Awake()         
        {
            Instance = this;
        }
    }
}
