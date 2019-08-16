using UnityEngine;

namespace Game
{
    public class GamePartManager:MonoBehaviour     
    {
        private  void Start()         
        {
            int index = 0;
            GamePart tempPart = null;
            foreach (Transform tran in transform)
            {
                index++;
                tempPart = tran.gameObject.AddComponent<GamePart>();
                tempPart.Init((LevelGamePartID)index);
            }
        }
    }
}
