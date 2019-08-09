using System.Collections.Generic;
using UnityEngine;

namespace CustomTool
{
    [System.Serializable]
    public class SubAnimatorMachineItem
    {
        public string SubMachineName;

        public List<GameObject> AnimationObjects = new List<GameObject>();
    }
}
