using UnityEngine;

namespace Game
{
    public class InitFeature : Feature   
    {
        public InitFeature(Contexts contexts,Services services):base("Init")
        {
            Add(new GameEventSystems(contexts));
            Add(new ViewFeature(contexts));
            Add(new SystemFeature(contexts));
            Add(new InitServiceFeature(contexts, services));
        }
    }
}
