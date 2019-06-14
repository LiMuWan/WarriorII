using Entitas;
using Entitas.Unity;
using Game.Service;
using UnityEngine;

namespace Game
{
    public class PlayerView : ViewService
    {
        public override void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity, contexts.game);//为什么重复代码不写在基类，因为不知道contexts是没有办法知道的
        }
    }
}
