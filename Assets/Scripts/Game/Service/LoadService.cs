﻿using System;
using Entitas;
using Game.Interface;
using Game.View;
using Manager;
using Manager.Parent;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 加载服务接口
    /// </summary>
    public interface ILoadService:ILoad,IInitService
    {
        /// <summary>
        /// 加载玩家预制
        /// </summary>
        void LoadPlayer();

        /// <summary>
        /// 加载敌人预制
        /// </summary>
        /// <param name="enemyName"></param>
        /// <param name="parent"></param>
        void LoadEnmey(string enemyName, Transform parent);
    }

    public class LoadService : ILoadService
    {
        private GameParentManager parentManager;

        public LoadService(GameParentManager parentManager)
        {
            this.parentManager = parentManager;
        }

        public int GetPriority()
        {
            return 0;
        }

        public void Init(Contexts contexts)
        {
            contexts.service.SetGameServiceLoadService(this);
        }

        public T Load<T>(string path, string name) where T : class
        {
           return LoadManager.Single.Load<T>(path, name);
        }

        public T[] LoadAll<T>(string path) where T : UnityEngine.Object
        {
            return LoadManager.Single.LoadAll<T>(path);
        }

        public GameObject LoadAndInstantiate(string path, Transform parent)
        {
            return LoadManager.Single.LoadAndInstantiate(path, parent);
        }

        public void LoadPlayer()
        {
            var player = LoadManager.Single.LoadAndInstantiate(Path.PLAYER_PATH, parentManager.GetParentTrans(ParentName.PlayerRoot));

            player.AddComponent<IgnoreForce>();
            player.AddComponent<PlayerCollider>();

            IView playerView = player.AddComponent<PlayerView>();
            IPlayerBehaviour playerBehaviour = new PlayerBehaviour(player.transform, ModelManager.Single.PlayerData);
            IPlayerAni playerAni = null;
            IPlayerAudio playerAudio = new PlayerAudio(player.GetComponentInChildren<AudioSource>());

            Animator animator = player.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("player身上未找到Animator组件！！！");
            }
            else
            {
                playerAni = new PlayerAni(animator, new CustomAniEventManager(animator));
            }

            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddGamePlayer(playerView, playerBehaviour, playerAni,playerAudio);
            entity.AddGamePlayerAniState(Const.PlayerAniIndex.IDLE);
            playerView.Init(Contexts.sharedInstance, entity);

            //加载刀光特效管理View
            LoadTrail(player.transform,animator);
        }

        public void LoadTrail(Transform player,Animator animator)
        {
            var trail = LoadAndInstantiate(Path.TRAILCOMBO_PATH, player);
            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            var manager = trail.AddComponent<TrailComboManager>();
            manager.Init(Contexts.sharedInstance, entity,animator);
        }

        public void LoadEnmey(string enemyName,Transform parent)
        {
            var enemy = LoadManager.Single.LoadAndInstantiate(Path.ENEMY_PATH + enemyName, parent);
            enemy.transform.localPosition = Vector3.zero;
            string scriptName = Consts.VIEW_NAMESPACE + "." + enemyName + Consts.VIEW_POSTFIX;
            Type viewType = Type.GetType(scriptName);
            IView view = null;
            if (viewType != null)
            {
               view = enemy.AddComponent(viewType) as IView;
            }
            else
            {
                Debug.LogError("未找到类,名称为 : " + scriptName);
                return;
            }

            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            view.Init(Contexts.sharedInstance, entity);
        }
    }
}
