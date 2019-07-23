using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 输入按键
    /// </summary>
    [Input,Unique]
    public class InputButtonComponent : IComponent
    {
        public InputButton InputButton;
        public InputState InputState;
    }


    /// <summary>
    /// 输入人物技能状态
    /// </summary>
    [Input, Unique]
    public class InputHumanSkillStateComponent:IComponent
    {
        /// <summary>
        /// 标记连续按键是否结束
        /// </summary>
        public bool IsEnd;
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }
}
