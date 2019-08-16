using UnityEngine;

namespace Game
{
    public class Part:MonoBehaviour     
    {
        private LevelPartID levelPartId;

        public void Init(LevelPartID levelPartId)
        {
            this.levelPartId = levelPartId;
        }
    }
}
