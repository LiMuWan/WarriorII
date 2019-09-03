using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class Part:MonoBehaviour     
    {
        public void Init(LevelGamePartID levelGamePartID, LevelPartID levelPartId)
        {
            AddScript<PartWall>(Const.ConstValue.LEVEL_PART_WALL);

            AddScript<SpawEnemyManager>(Const.ConstValue.LEVEL_PART_SPAW_POINT);
        }

        private void AddScript<T>(string name) where T : MonoBehaviour
        {
            Transform obj = transform.Find(name);
            if (obj != null)
            {
                obj.gameObject.AddComponent<T>();
            }
            else
            {
                Debug.LogError("未找到Part下的Wall父物体");
            }
        }
    }
}
