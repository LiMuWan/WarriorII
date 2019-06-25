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
}
