using Entitas;
using UnityEngine;

namespace Game
{
    public class ExcuteServiceSystem : IExecuteSystem   
    {
        private Contexts contexts;
        private Services services;

        public ExcuteServiceSystem(Contexts contexts,Services services)
        {
            this.contexts = contexts;
            this.services = services;
        }

        public void Execute()
        {
            services.UnityInputService.Excute();
            services.TimerService.Excute();
        }
    }
}
