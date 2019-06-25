﻿using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 初始化服务系统
    /// </summary>
    public class InitServiceSystem : IInitializeSystem
    {
        private Contexts contexts;
        private ServiceManager services;
        public InitServiceSystem(Contexts contexts,ServiceManager services)
        {
            this.contexts = contexts;
            this.services = services;
        }

        public void Initialize()
        {
            InitUniqueComponents(contexts, services);
            InitService(contexts, services);
        }

        public void InitService(Contexts contexts,ServiceManager services)
        {
            //services.EntitasInputService.Init(contexts);
            //services.UnityInputService.Init(contexts);
        }

        /// <summary>
        /// 初始化单例组件
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        public void InitUniqueComponents(Contexts contexts, ServiceManager services)
        {
           
            
            
           
        }
    }
}
