using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public abstract class InputButtonSystemBase : ReactiveSystem<InputEntity>
    {
        protected Contexts contexts;
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
            return entity.hasGameInputButton && entity.gameInputButton.InputButton != InputButton.NONE && FilterCondition(entity);
        }
        /// <summary>
        /// 事件执行的筛选条件
        /// </summary>
        /// <returns></returns>
        protected abstract bool FilterCondition(InputEntity entity);
 
    }
}
