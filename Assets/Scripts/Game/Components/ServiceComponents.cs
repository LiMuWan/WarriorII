using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;

namespace Game.Service
{
    /// <summary>
    /// ���ҷ������
    /// </summary>
    [Service,Unique]
    public class FindObjectServiceComponent:IComponent
    {
        public IFindObjectService FindObjectService;
    }


    /// <summary>
    /// ����������
    /// </summary>
    [Service, Unique]
    public class EntitasInputServiceComponent:IComponent
    {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// ��־������� 
    /// </summary>
    [Service, Unique]
    public class LogServiceComponent:IComponent
    {
        public ILogService LogService;
    }

    /// <summary>
    /// ���ط������
    /// </summary>
    [Service, Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService LoadService; 
    }

    /// <summary>
    /// ��ʱ���������
    /// </summary>
    [Service, Unique]
    public class TimerServiceComponent:IComponent
    {
        public TimerService TimerService;
    }
}
