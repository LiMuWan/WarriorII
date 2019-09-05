using UnityEngine;

namespace GOAP
{
    public abstract class DebugBase
    {
        public static DebugBase Instance { get; set; }

        public abstract void Log(string msg);

        public abstract void LogWarning(string msg);

        public abstract void LogError(string msg);
    }
}
