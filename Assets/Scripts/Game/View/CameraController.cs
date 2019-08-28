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
            InitFollowPlayer();
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
                       cameraMove.Move(parent, StartCameraCallBack);
                    break;
                case CameraAniName.SHAKE:
                    Shake();
                    break;
                case CameraAniName.FOLLOW_PLAYER:
                    parent = GetCameraParent(CameraParent.FOLLOW_PLAYER);
                    if (parent != null)
                        cameraMove.Move(parent, null);
                    break;
            }
        }

        private void StartCameraCallBack()
        {
            Contexts.sharedInstance.game.ReplaceGameCameraState(CameraAniName.FOLLOW_PLAYER);
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
            if (DataManager.Single.LevelGamePartIndex == LevelGamePartID.ONE)
            {
                parent = GetCameraParent(CameraParent.START);
            }
            else
            {
                parent = GetCameraParent(CameraParent.IN_GAME);
            }

            if (parent != null) cameraMove.Init(parent);
        }

        private void InitFollowPlayer()
        {
            parentDic[CameraParent.FOLLOW_PLAYER].gameObject.AddComponent<FollowPlayer>();
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
