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
    /// 输入人物技能部分
    /// </summary>
    [Input, Unique,Event(EventTarget.Self)]
    public class InputValidHumanSkillComponent:IComponent
    {
        /// <summary>
        /// 标记连续按键是否有效
        /// </summary>
        public bool IsValid;
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }
}
