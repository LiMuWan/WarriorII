using Const;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Interface;
using Game.Service;
using Module.Timer;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 相机动画状态，根据此状态的改变播放相机动画
    /// </summary>
    [Game, Event(EventTarget.Self),Unique ]
    public class CameraState : IComponent
    {
        public CameraAniName State;
    }

    /// <summary>
    /// 游戏状态
    /// </summary>
    [Game,Unique]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }

    /// <summary>
    /// 玩家
    /// </summary>
    [Game,Unique]
    public class PlayerComponent : IComponent
    {
        public IView PlayerView;
        public IPlayerBehaviour PlayerBehaviour;
        public IPlayerAni PlayerAni;
    }

    /// <summary>
    /// 玩家动画
    /// </summary>
    [Game]
    public class PlayerAniState : IComponent
    {
        public PlayerAniIndex PlayerAniIndex;
    }

    /// <summary>
    /// 输入人物技能部分
    /// </summary>
    [Game, Unique, Event(EventTarget.Self)]
    public class ValidHumanSkillComponent : IComponent
    {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }
}
