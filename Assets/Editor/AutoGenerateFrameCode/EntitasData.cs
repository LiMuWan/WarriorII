using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class EntitasData : ScriptableObject
    {
        /// <summary>
        /// View ��·��
        /// </summary>
        public string ViewPath;
        /// <summary>
        /// Service ��·��
        /// </summary>
        public string ServicePath;
        /// <summary>
        /// System ��·��
        /// </summary>
        public string SystemPath;

        /// <summary>
        /// ServiceManager·��
        /// </summary>
        public string ServiceManagerPath;
    }
}
