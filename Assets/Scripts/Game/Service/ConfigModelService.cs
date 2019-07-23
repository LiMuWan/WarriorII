using Game.Interface;

namespace Game.Service
{

    public interface IModelService:IInitService     
    {
    }

    public interface IConfigModelService : IModelService
    {
    }

    /// <summary>
    /// 配置数据服务
    /// </summary>
    public class ConfigModelService:IConfigModelService     
    {
        public  void Init(Contexts contexts)        
        {
            //contexts.service.SetGameServiceConfigModelService(this);
        }

        public  int GetPriority()         
        {
            return 0;
        }
    }
}
