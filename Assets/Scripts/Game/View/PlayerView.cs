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
            gameObject.Link(entity, contexts.game);//Ϊʲô�ظ����벻д�ڻ��࣬��Ϊ��֪��contexts��û�а취֪����
        }
    }
}
