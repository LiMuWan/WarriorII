using UnityEngine;

namespace Game
{
    public class InitFeature : Feature   
    {
        public InitFeature(Contexts contexts):base("Init")
        {
            Add(new ViewFeature(contexts));
            Add(new SystemFeature(contexts));
        }
    }
}
