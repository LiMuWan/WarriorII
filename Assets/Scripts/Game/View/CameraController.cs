using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour,IInitializeSystem,IGameCameraStateListener
    {
        public void Initialize()
        {
            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            gameObject.Link(entity, Contexts.sharedInstance.game);
            entity.AddGameCameraStateListener(this);
        }

        public void OnGameCameraState(GameEntity entity, CameraAniName state)
        {
              
        }
    }
}
