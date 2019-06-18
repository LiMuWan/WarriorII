using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public interface ILogService:IInitService
    {
        void Log(string message);
        void LogError(string message);
    }

    public class LogService :ILogService   
    {
        public int GetPriority()
        {
            return 0;
        }

        public void Init(Contexts contexts)
        {
            contexts.service.SetGameServiceLogService(this);
        }

        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void LogError(string message)
        {
            Debug.LogError(message); 
        }
    }
}
