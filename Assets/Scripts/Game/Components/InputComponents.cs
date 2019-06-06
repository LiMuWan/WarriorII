using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���밴��
    /// </summary>
    [Input,Unique]
    public class InputButtonComponent : IComponent
    {
        public InputButton InputButton;
    }
}
