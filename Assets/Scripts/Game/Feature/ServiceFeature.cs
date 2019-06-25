using UnityEngine;

namespace Game
{
    public class ServiceFeature : Feature    
    {
        public ServiceFeature(Contexts contexts,ServiceManager services):base("InitService")
        {
            Add(new InitServiceSystem(contexts,services));
            Add(new ExcuteServiceSystem(contexts, services));
        }
    }
}
