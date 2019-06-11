using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class PlayerView : ViewService,IPlayerBehaviour
    {
        public override void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity, contexts.game);//为什么重复代码不写在基类，因为不知道contexts是没有办法知道的
            contexts.game.SetGamePlayer(this); 
        }
 
        public void Up()
        {
            throw new System.NotImplementedException();
        }

        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public void AttackO()
        {
            throw new System.NotImplementedException();
        }

        public void AttackX()
        {
            throw new System.NotImplementedException();
        }
    }
}
