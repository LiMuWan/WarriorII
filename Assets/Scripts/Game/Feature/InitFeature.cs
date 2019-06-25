using UnityEngine;

namespace Game
{
    public class InitFeature : Feature   
    {
        public InitFeature(Contexts contexts):base("Init")
        {
            Add(new GameEventSystems(contexts));
            Add(new GameFeature(contexts));
            Add(new ViewFeature(contexts));
            Add(new InputFeature(contexts));   
        }
    }
}
