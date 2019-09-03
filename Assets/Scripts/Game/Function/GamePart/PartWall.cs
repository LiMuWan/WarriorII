using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class PartWall:MonoBehaviour     
    {
        public void Init(LevelGamePartID levelGamePartID, LevelPartID levelPartId)
        {
            ZamekEffect[] zamekEffects = InitZamek(transform);
            bool isOpen = JudgeOpenState(levelGamePartID, levelPartId);
            SetOpenState(isOpen, zamekEffects);

            WallCollider[] wallColliders = InitWallCollider(transform);
            SetWallState(isOpen, wallColliders);

            InitStartPartTrigger(wallColliders, zamekEffects, levelGamePartID, levelPartId);
        }

        /// <summary>
        /// 判断该关卡是否处于开放状态
        /// </summary>
        /// <returns></returns>
        public bool JudgeOpenState(LevelGamePartID levelGamePartID, LevelPartID levelPartId)
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

        private void SetOpenState(bool isOpen, ZamekEffect[] zamekEffects)
        {
            foreach (ZamekEffect effect in zamekEffects)
            {
                effect.OpenZamekState(isOpen);
            }
        }

        private WallCollider[] InitWallCollider(Transform wall)
        {
            Collider[] colliders = wall.GetComponentsInChildren<Collider>();
            WallCollider[] walls = new WallCollider[colliders.Length];

            for (int i = 0; i < colliders.Length; i++)
            {
                walls[i] = colliders[i].gameObject.AddComponent<WallCollider>();
                walls[i].Init(colliders[i]);
            }

            return walls;
        }

        private void SetWallState(bool isOpen, WallCollider[] walls)
        {
            foreach (WallCollider wall in walls)
            {
                wall.SetWallState(isOpen);
            }
        }

        private void InitStartPartTrigger(WallCollider[] wallColliders, ZamekEffect[] zamekEffects, LevelGamePartID levelGamePartID, LevelPartID levelPartId)
        {
            StartPartTrigger trigger = transform.parent.gameObject.AddComponent<StartPartTrigger>();
            trigger.Init(() => { StartPartTrigger(wallColliders, zamekEffects, levelGamePartID, levelPartId); });
        }

        private void StartPartTrigger(WallCollider[] wallColliders, ZamekEffect[] zamekEffects, LevelGamePartID levelGamePartID, LevelPartID levelPartId)
        {
            SetOpenState(false, zamekEffects);
            SetWallState(false, wallColliders);
            DataManager.Single.LevelGamePartIndex = levelGamePartID;
            DataManager.Single.LevelPartIndex = levelPartId;
        }
    }
}
