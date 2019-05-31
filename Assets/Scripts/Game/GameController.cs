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
            systems.Execute();//每一帧执行
            systems.Cleanup();//每一帧执行完之后调用
        }

        private void OnDestroy()
        {
            systems.TearDown();
        }
    }
}
