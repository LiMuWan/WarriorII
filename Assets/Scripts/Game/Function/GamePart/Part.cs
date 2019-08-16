using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class Part:MonoBehaviour     
    {
        private LevelGamePartID levelGamePartID;
        private LevelPartID levelPartId;
        private ZamekEffect[] zamekEffects;

        public void Init(LevelGamePartID levelGamePartID,LevelPartID levelPartId)
        {
            this.levelGamePartID = levelGamePartID;
            this.levelPartId = levelPartId;
            Transform wall = transform.Find(Const.ConstValue.LEVEL_PART_WALL);
            zamekEffects = InitZamek(wall);
            bool isOpen = JudgeOpenState();
            SetOpenState(isOpen);
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

        private ZamekEffect[] InitZamek(Transform wall)
        {
            MeshRenderer[] renders = wall.GetComponentsInChildren<MeshRenderer>();
            ZamekEffect[] zamekEffects = new ZamekEffect[renders.Length];
            for (int i = 0; i < renders.Length; i++)
            {
                zamekEffects[i] = renders[i].gameObject.AddComponent<ZamekEffect>();
                zamekEffects[i].Init();
            }
            return zamekEffects;
        }

        private void SetOpenState(bool isOpen)
        {
            foreach (ZamekEffect effect in zamekEffects)
            {
                effect.OpenZamekState(isOpen);
            }
        }
    }
}
