using UnityEngine;

namespace Game
{
    public class ViewFeature : Feature    
    {
        public ViewFeature(Contexts contexts) : base("View")
        {
            Init(contexts);
        }

        private void Init(Contexts contexts )
        {
            Add(new InitViewSystem(contexts)); 
        }
    }
}
 