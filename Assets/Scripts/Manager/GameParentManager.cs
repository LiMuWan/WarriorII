using System.Collections.Generic;
using UnityEngine;

namespace Manager.Parent
{
    /// <summary>
    /// 场景内父物体管理类
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
        /// 通过父物体名称获取父物体对象
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
        /// 通过父物体名称获取父物体对象
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
