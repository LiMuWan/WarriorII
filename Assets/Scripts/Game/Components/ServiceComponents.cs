using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;

namespace Game.Component
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

    /// <summary>
    /// ���ط������
    /// </summary>
    [Game,Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService LoadService; 
    }

    /// <summary>
    /// ��ʱ���������
    /// </summary>
    [Game,Unique]
    public class TimerServiceComponent:IComponent
    {
        public TimerService TimerService;
    }
}
