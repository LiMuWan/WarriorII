using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class EntitasData : ScriptableObject
    {
        /// <summary>
        /// View ��·��
        /// </summary>
        public string viewPath;
        /// <summary>
        /// Service ��·��
        /// </summary>
        public string servicePath;
        /// <summary>
        /// System ��·��
        /// </summary>
        public string systemPath;
    }
}
