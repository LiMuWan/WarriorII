using System.Collections.Generic;
using UnityEngine;

namespace Manager.Parent
{
    /// <summary>
    /// �����ڸ����������
    /// </summary>
    public class GameParentManager : MonoBehaviour    
    {
        private Dictionary<string, Transform> parentTransDic;

        public void Init()
        {
            parentTransDic = new Dictionary<string, Transform>();
            foreach (Transform trans in transform)
            {
                parentTransDic[trans.name] = trans;
            }
        }

        /// <summary>
        /// ͨ�����������ƻ�ȡ���������
        /// </summary>
        /// <param name="parentName"></param>
        /// <returns></returns>
        public Transform GetParentTrans(string parentName)
        {
            Transform parent = null;
            parentTransDic.TryGetValue(parentName, out parent);

            return parent;
        }

        /// <summary>
        /// ͨ�����������ƻ�ȡ���������
        /// </summary>
        /// <param name="parentName"></param>
        /// <returns></returns>
        public Transform GetParentTrans(ParentName parentName)
        {
            Transform parent = null;
            parentTransDic.TryGetValue(parentName.ToString() , out parent);

            return parent;
        }
    }

    public enum ParentName
    {
        PlayerRoot,
        CameraController
    }
}
