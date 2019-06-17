using Game.Interface;
using Game.Service;
using Manager.Parent;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IServiceManager:IInitService,IExecuteService 
    {

    }
    public class ServiceManager:IServiceManager     
    {
        private HashSet<IInitService> initServices;
        private HashSet<IExecuteService> executeServices;

        public ITimerService TimerService { get; private set; }

        public ServiceManager(GameParentManager gameParentManager)
        {
            initServices = new HashSet<IInitService>();
            executeServices = new HashSet<IExecuteService>();  

            AddInitServices(this,gameParentManager);
            AddExecuteServices(this);
        }

        public void AddInitService(IInitService service)
        {
            initServices.Add(service);
        }

        public void AddExecuteService(IExecuteService service)
        {
            executeServices.Add(service);
        }

        public void Init(Contexts contexts)
        {
            foreach (IInitService service in initServices)
            {
                service.Init(contexts);
            }
        }

        public void Execute()
        {
            foreach (IExecuteService service in executeServices)
            {
                service.Execute();
            }
        }

        private void AddInitServices(ServiceManager services,GameParentManager gameParentManager)
        {
            services.AddInitService(new FindObjectService());
            services.AddInitService(new EntitasInputService());
            services.AddInitService(new UnityInputService());
            services.AddInitService(new LogService());
            services.AddInitService(new LoadService(gameParentManager));
            services.AddInitService(new TimerService());
        }

        private void AddExecuteServices(ServiceManager services)
        {
            services.AddExecuteService(new EntitasInputService());
            services.AddExecuteService(new UnityInputService());
            services.AddExecuteService(new TimerService());
        }
    }
}
