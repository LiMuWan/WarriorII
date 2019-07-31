using Const;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Interface;

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
    /// 输入人物技能组件
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class ValidHumanSkillComponent : IComponent 
    {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// 玩家行为状态组件
    /// </summary>
    [Game,Unique]
    public class HumanBehaviourStateComponent : IComponent
    {
        /// <summary>
        /// 玩家行为状态
        /// </summary>
        public PlayerBehaviourIndex PlayerBehaviourIndex;

        /// <summary>
        /// 状态机状态
        /// </summary>
        public BehaviourState BehaviourState;
    }

    /// <summary>
    /// 人物技能开始组件
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class StartHumanSkillComponent : IComponent
    {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// 人物技能结束组件
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class EndHumanSkillComponent : IComponent
    {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }
}
