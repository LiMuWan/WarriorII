﻿using Manager;
using UnityEngine;

namespace Game.GamePart
{
    public class Part:MonoBehaviour     
    {
        public void Init(LevelGamePartID levelGamePartID,LevelPartID levelPartId)
        {
            Transform wall = transform.Find(Const.ConstValue.LEVEL_PART_WALL);

            ZamekEffect[] zamekEffects = InitZamek(wall);
            bool isOpen = JudgeOpenState(levelGamePartID, levelPartId);
            SetOpenState(isOpen, zamekEffects);

            WallCollider[] wallColliders = InitWallCollider(wall);
            SetWallState(isOpen, wallColliders);

            InitStartPartTrigger();
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

        private void SetWallState(bool isOpen,WallCollider[] walls)
        {
            foreach (WallCollider wall in walls)
            {
                wall.SetWallState(isOpen);
            }
        }

        private void InitStartPartTrigger()
        {
            gameObject.AddComponent<StartPartTrigger>();
        }
    }
}
