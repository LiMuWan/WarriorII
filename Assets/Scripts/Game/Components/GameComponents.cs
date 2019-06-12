using Const;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������״̬�����ݴ�״̬�ĸı䲥���������
    /// </summary>
    [Game, Event(EventTarget.Self),Unique ]
    public class CameraState : IComponent
    {
        public CameraAniName State;
    }

    /// <summary>
    /// ��Ϸ״̬
    /// </summary>
    [Game,Unique]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }

    /// <summary>
    /// ���
    /// </summary>
    [Game,Unique]
    public class PlayerComponent : IComponent
    {
        public IView PlayerView;
        public IPlayerBehaviour PlayerBehaviour;
        public IPlayerAni PlayerAni;
    }

    /// <summary>
    /// ��Ҷ���
    /// </summary>
    [Game]
    public class PlayerAniState : IComponent
    {
        public PlayerAniIndex PlayerAniIndex;
    }
}
