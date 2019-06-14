using Game.Interface;
using Game.Service;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Services     
    {
        private HashSet<IInitService> initServices;
        private HashSet<IExecuteService> executeServices;
        public IFindObjectService   FindObjectService { get; private set; }
        public IInputService        EntitasInputService { get; private set; }
        public IInputService        UnityInputService { get; private set; }
        public ILogService          LogService { get; private set; }
        public ILoadService         LoadService { get; private set; }

        public ITimerService TimerService { get; private set; }

        public Services()
        {
            initServices = new HashSet<IInitService>();
            executeServices = new HashSet<IExecuteService>();
        }

        public void AddInitService(IInitService service)
        {
            initServices.Add(service);
        }

        public void AddExecuteService(IExecuteService service)
        {
            executeServices.Add(service);
        }
    }
}
