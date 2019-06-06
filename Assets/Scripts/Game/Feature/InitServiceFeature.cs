using UnityEngine;

namespace Game
{
    public class InitServiceFeature : Feature    
    {
        public InitServiceFeature(Contexts contexts,Services services):base("InitService")
        {
            Add(new InitServiceSystem(contexts,services));
            Add(new ExcuteServiceSystem(contexts, services));
        }
    }
}
