using UnityEngine;

namespace Game.GamePart
{
    public class GamePart:MonoBehaviour     
    {
        private LevelGamePartID levelGamePartId;
        
        public void Init(LevelGamePartID id)
        {
            levelGamePartId = id;
        }

        private void InitPart()
        {
            Part tempPart = null;
            int index = 0;
            foreach (Transform trans in transform)
            {
                index++;
                tempPart = trans.gameObject.AddComponent<Part>();
                tempPart.Init(levelGamePartId, (LevelPartID)index);
            }
        }
    }
}
