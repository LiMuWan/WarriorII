using Entitas;
using Entitas.Unity;
using Game.Service;
using UnityEngine;

namespace Game
{
    public class PlayerView : ViewBase
    {
        public override void Init(Contexts contexts, IEntity entity)
        {
            base.Init(contexts,entity); 
        }
    }
}
