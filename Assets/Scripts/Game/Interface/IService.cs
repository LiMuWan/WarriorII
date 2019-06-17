using UnityEngine;

namespace Game.Interface
{
    /// <summary>
    /// ÿ��Service������ʵ��IInitService
    /// </summary>
    public interface IInitService 
    {
        void Init(Contexts contexts);

        /// <summary>
        /// ��ȡ���ȼ�
        /// </summary>
        /// <returns></returns>
        int GetPriority();
    }

    public interface IExecuteService
    {
        void Execute();
    }
}
