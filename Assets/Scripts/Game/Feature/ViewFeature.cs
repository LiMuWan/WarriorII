using UnityEngine;

namespace Game
{
    public class ViewFeature : Feature    
    {
        public ViewFeature(Contexts contexts): base("View")
        {
            Init();
        }

        private void Init()
        {
            Add(new InitViewSystem());
        }
    }
}
