using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ��ʼ������ϵͳ
    /// </summary>
    public class InitServiceSystem : IInitializeSystem
    {
        private Contexts contexts;
        private Services services;
        public InitServiceSystem(Contexts contexts,Services services)
        {
            this.contexts = contexts;
            this.services = services;
        }

        public void Initialize()
        {
            InitUniqueComponents(contexts, services);
            InitService(contexts, services);
        }

        public void InitService(Contexts contexts,Services services)
        {
            services.EntitasInputService.Init(contexts);
            services.UnityInputService.Init(contexts);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        public void InitUniqueComponents(Contexts contexts, Services services)
        {
            contexts.game.SetGameFindObjectService(services.FindObjectService);
            contexts.game.SetGameEntitasInputService(services.EntitasInputService);
        }
    }
}
