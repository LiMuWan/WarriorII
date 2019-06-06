using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���ҷ������
    /// </summary>
    [Game,Unique]
    public class FindObjectServiceComponent:IComponent
    {
        public IFindObjectService FindObjectService;
    }


    /// <summary>
    /// ����������
    /// </summary>
    [Game,Unique]
    public class EntitasInputServiceComponent:IComponent
    {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// ��־������� 
    /// </summary>
    [Game,Unique]
    public class LogServiceComponent:IComponent
    {
        public ILogService LogService;
    }
}
