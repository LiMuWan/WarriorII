using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class PlayerView : ViewService,IPlayerBehaviour
    {
        public override void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity, contexts.game);//Ϊʲô�ظ����벻д�ڻ��࣬��Ϊ��֪��contexts��û�а취֪����
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
