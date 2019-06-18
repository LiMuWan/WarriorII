using UnityEngine;

namespace Game
{

    /// <summary>
    /// �������״̬����
    /// </summary>
    public enum CameraAniName
    {
        /// <summary>
        /// Ĭ��
        /// </summary>
        NONE,
        /// <summary>
        /// �����������
        /// </summary>
        START_GAME_ANI
    }

    public enum CameraParent
    {
        START,
        IN_GAME
    }

    /// <summary>
    /// �ؿ�ID
    /// </summary>
    public enum LevelID
    {
        ONE = 1,
        TWO = 2,
    }

    /// <summary>
    /// �ؿ�����ID
    /// </summary>
    public enum LevelPartID
    {
        ONE = 1,
        TWO
    }

    /// <summary>
    /// ���밴ť 
    /// </summary>
    public enum InputButton
    {
        NONE,
        FORWARD,
        BACK,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    public enum InputState
    {
        NONE,
        UP,
        PRESS,
        DOWN,
    }

    /// <summary>
    /// ��Ϸ״̬
    /// </summary>
    public enum GameState
    {
        START,
        PAUSE,
        END
    }
}
