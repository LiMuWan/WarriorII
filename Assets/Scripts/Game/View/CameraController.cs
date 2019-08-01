using Entitas;
using Manager;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Game
{
    public class CameraController : ViewBase,IGameCameraStateListener
    {
        private Dictionary<CameraParent, Transform> parentDic;
        private CameraMove cameraMove;
        private Camera camera;
        public override void Init(Contexts contexts,IEntity entity)
        {
            base.Init(contexts, entity);
            InitParent();
            InitCamera();
            ((GameEntity)entity).AddGameCameraStateListener(this);
        }

        public void OnGameCameraState(GameEntity entity, CameraAniName state)
        {
            Transform parent = null;
            switch (state)
            {
                case CameraAniName.START_GAME_ANI:
                    parent = GetCameraParent(CameraParent.IN_GAME);
                    if(parent != null)
                       cameraMove.Move(parent);
                    break;
                case CameraAniName.SHAKE:
                    Shake();
                    break;
            }
        }

        private void InitParent()
        {
            parentDic = new Dictionary<CameraParent, Transform>();
            Transform temp;
            foreach (CameraParent parent in Enum.GetValues(typeof(CameraParent)))
            {
                temp = transform.Find(parent.ToString());
                if (temp != null)
                {
                    parentDic[parent] = temp;
                    temp = null;
                }
            }
        }

        private void InitCamera()
        {
            camera = transform.GetComponentInChildren<Camera>();
            if (camera == null)
            {
                Debug.LogError("无法查找到相机");
            }
            else
            {
               cameraMove = camera.gameObject.AddComponent<CameraMove>();
            }

            if (cameraMove == null) return;

            Transform parent = null;
            if (DataManager.Single.LevelPartIndex == LevelPartID.ONE)
            {
                parent = GetCameraParent(CameraParent.START);
            }
            else
            {
                parent = GetCameraParent(CameraParent.IN_GAME);
            }

            if (parent != null) cameraMove.Init(parent);
        }

        private Transform GetCameraParent(CameraParent parent)
        {
            Transform parentTrans = null;
            parentDic.TryGetValue(parent, out parentTrans);
            return parentTrans;
        }

        private void Shake()
        {
            camera.DOShakePosition(0.5f, 0.2f, 20);
        }
    }
}
