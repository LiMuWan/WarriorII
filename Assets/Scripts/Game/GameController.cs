using Entitas;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        public void Start()
        {
            systems = new InitFeature(Contexts.sharedInstance);
            systems.Initialize(); 
        }

        private void Update()
        {
            systems.Execute();//ÿһִ֡��
            systems.Cleanup();//ÿһִ֡����֮�����
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
