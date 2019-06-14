using UnityEngine;

namespace Game.Interface
{
    /// <summary>
    /// ������Ϊ�ӿ�
    /// </summary>
    public interface IBehaviour
    {
        void Forward();
        void Back();
        void Left();
        void Right();
    }

    /// <summary>
    /// �����Ϊ�ӿ�
    /// </summary>
    public interface IPlayerBehaviour:IBehaviour
    {
        /// <summary>
        /// ����
        /// </summary>
        void Idle();
        /// <summary>
        /// ������������K��
        /// </summary>
        void AttackO();
        /// <summary>
        /// ������������L)
        /// </summary>
        void AttackX();
    }
}
