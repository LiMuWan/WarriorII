﻿using Game.Interface;
using Game.Service;
using Manager.Parent;
using Module.Timer;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public interface IServiceManager:IInitService,IExecuteService 
    {

    }
    public class ServiceManager:IServiceManager     
    {
        private Dictionary<int,HashSet<IInitService>> initServices;
        private HashSet<IExecuteService> executeServices;

        public ITimerService TimerService { get; private set; }

        public ServiceManager(GameParentManager gameParentManager)
        {
            initServices = new Dictionary<int, HashSet<IInitService>>();
            executeServices = new HashSet<IExecuteService>();

            IInitService[] services = InitServices(gameParentManager);

            AddInitServices(services, gameParentManager);
            AddExecuteServices(services);

            var result = from temp in initServices orderby temp.Key select temp;
            initServices = result.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        ///Service 初始化
        /// </summary>
        /// <param name="gameParentManager"></param>
        /// <returns></returns>
        private IInitService[] InitServices(GameParentManager gameParentManager)
        {
            IInitService[] services =
            {
                   new ConfigModelService(), 
                   new SkillCodeService(), 
                   new FindObjectService(),
                   new EntitasInputService(),
                   new LogService(),
                   new LoadService(gameParentManager),
                   new TimerService(new TimerManager()),
                   new UnityInputService(),
            };
            return services;
        }

        /// <summary>
        /// 优先级
        /// </summary>
        /// <param name="priority">优先级</param>
        /// <param name="service">service</param>
        private void AddInitService(int priority,IInitService service)
        {
            if(priority < 0)
            {
                Debug.LogError("优先级不能为负，应从0开始！");
                return;
            }
            if(!initServices.ContainsKey(priority))
            {
                initServices[priority] = new HashSet<IInitService>();
            }
            initServices[priority].Add(service);
        }

        private void AddExecuteService(IExecuteService service)
        {
            executeServices.Add(service);
        }

        public void Init(Contexts contexts)
        {
            foreach (KeyValuePair<int,HashSet<IInitService>> services in initServices)
            {
                foreach (IInitService service in services.Value)
                {
                    service.Init(contexts);
                }
            }
        }

        public void Execute()
        {
            foreach (IExecuteService service in executeServices)
            {
                service.Execute();
            }
        }

        private void AddInitServices(IInitService[] services, GameParentManager gameParentManager)
        {
            foreach (IInitService service in services)
            {
                AddInitService(service.GetPriority(), service);
            }
        }

        private void AddExecuteServices(IInitService[] services)
        {
            foreach (IInitService service in services)
            {
                IExecuteService executeService = service as IExecuteService;
                if(executeService != null)
                {
                    AddExecuteService(executeService);
                }
            }
        }

        public int GetPriority()
        {
            return 0;
        }
    }
}
