using Entitas;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        public void Start()
        {
            Services services = new Services(new FindObjectService(),
                                        new EntitasInputService(),
                                        new UnityInputService(),
                                        new LogService());

            systems = new InitFeature(Contexts.sharedInstance,services);

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
