using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class EntitasData : ScriptableObject
    {
        /// <summary>
        /// View 层路径
        /// </summary>
        public string ViewPath;
        /// <summary>
        /// Service 层路径
        /// </summary>
        public string ServicePath;
        /// <summary>
        /// System 层路径
        /// </summary>
        public string SystemPath;

        /// <summary>
        /// ServiceManager路径
        /// </summary>
        public string ServiceManagerPath;
    }
}
