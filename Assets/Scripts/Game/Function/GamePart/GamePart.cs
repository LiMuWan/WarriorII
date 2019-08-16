using UnityEngine;

namespace Game
{
    public class GamePart:MonoBehaviour     
    {
        private LevelGamePartID gamePartId;

        public void Init(LevelGamePartID id)
        {
            gamePartId = id;
        }

        private void InitPart()
        {
            Part tempPart = null;
            int index = 0;
            foreach (Transform trans in transform)
            {
                index++;
                tempPart = trans.gameObject.AddComponent<Part>();
                tempPart.Init((LevelPartID)index);
            }
        }
    }
}
