using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class Part:MonoBehaviour     
    {
        private LevelGamePartID levelGamePartID;
        private LevelPartID levelPartId;

        public void Init(LevelGamePartID levelGamePartID,LevelPartID levelPartId)
        {
            this.levelGamePartID = levelGamePartID;
            this.levelPartId = levelPartId;
            transform.Find(Const.ConstValue.LEVEL_PART_WALL);
        }

        /// <summary>
        /// 判断该关卡是否处于开放状态
        /// </summary>
        /// <returns></returns>
        public bool JudgeOpenState()
        {
            return levelGamePartID <= DataManager.Single.LevelGamePartIndex
                && levelPartId <= DataManager.Single.LevelPartIndex;
        }
    }
}
