using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class CustomDebug : DebugBase
    {
        public override void Log(string msg)
        {
            Debug.Log(msg);
        }

        public override void LogError(string msg)
        {
            Debug.LogError(msg);
        }

        public override void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }
    }
}
