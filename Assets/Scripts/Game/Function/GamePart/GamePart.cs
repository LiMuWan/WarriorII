using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class GamePart:MonoBehaviour     
    {
        
        public void Init(LevelGamePartID levelGamePartId)
        {
            InitPart(levelGamePartId);
        }

        public void InitPart(LevelGamePartID levelGamePartId)
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
