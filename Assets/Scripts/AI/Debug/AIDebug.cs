using UnityEngine;
using BlueGOAP;

namespace Game.AI
{
    public class AIDebug : DebugMsgBase
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
