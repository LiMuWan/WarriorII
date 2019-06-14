using Game.Interface;
using UnityEngine;

namespace Game.Service
{
    public interface ILogService:IService
    {
        void Log(string message);
        void LogError(string message);
    }

    public class LogService :ILogService   
    {
        public void Init(Contexts contexts)
        {
            contexts.game.SetGameLogService(this);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
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
