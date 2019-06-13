using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public abstract class InputButtonSystemBase : ReactiveSystem<InputEntity>
    {
        protected Contexts contexts;
        protected PlayerComponent player;
        public InputButtonSystemBase(Contexts contexts):base(contexts.input)
        {
            this.contexts = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.GameInputButton);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasGameInputButton && FilterCondition(entity);
        }
        /// <summary>
        /// 事件执行的筛选条件
        /// </summary>
        /// <returns></returns>
        protected abstract bool FilterCondition(InputEntity entity);
 
    }
}
