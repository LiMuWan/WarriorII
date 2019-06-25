using UnityEngine;

namespace Game.Interface
{
    /// <summary>
    /// 每个Service都必须实现IInitService
    /// </summary>
    public interface IInitService 
    {
        void Init(Contexts contexts);

        /// <summary>
        /// 获取优先级
        /// </summary>
        /// <returns></returns>
        int GetPriority();
    }

    public interface IExecuteService
    {
        void Execute();
    }
}
