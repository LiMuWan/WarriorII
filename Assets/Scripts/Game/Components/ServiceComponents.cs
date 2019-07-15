﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;

namespace Game.Service
{
    /// <summary>
    /// 查找服务组件
    /// </summary>
    [Service,Unique]
    public class FindObjectServiceComponent:IComponent
    {
        public IFindObjectService FindObjectService;
    }


    /// <summary>
    /// 输入服务组件
    /// </summary>
    [Service, Unique]
    public class EntitasInputServiceComponent:IComponent
    {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// 日志服务组件 
    /// </summary>
    [Service, Unique]
    public class LogServiceComponent:IComponent
    {
        public ILogService LogService;
    }

    /// <summary>
    /// 加载服务组件
    /// </summary>
    [Service, Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService LoadService; 
    }

    /// <summary>
    /// 计时器服务组件
    /// </summary>
    [Service, Unique]
    public class TimerServiceComponent:IComponent
    {
        public TimerService TimerService;
    }

    /// <summary>
    /// SkillCode服务组件
    /// </summary>
    [Service,Unique]
    public class SkillCodeServiceComponent:IComponent
    {
        public SkillCodeService SkillCodeService;
    }
}
