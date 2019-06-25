using Const;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class UILayerManager : MonoBehaviour    
    {
        private Dictionary<UILayer, Transform> layerDictionary = new Dictionary<UILayer, Transform>();
        private void Awake()        
        {
            Transform temp = null;
            foreach (UILayer layer in Enum.GetValues(typeof(UILayer)))
            {
                temp = transform.Find(layer.ToString());
                if(temp == null)
                {
                    Debug.LogErrorFormat("can't find layer == {0} GameObject", layer.ToString());
                    continue;
                }
                else
                {
                    layerDictionary[layer] = temp;
                }
            }
        }

        public Transform GetLayerObject(UILayer layer)
        {
            if(layerDictionary.ContainsKey(layer))
            {
                return layerDictionary[layer];
            }
            else
            {
                Debug.LogErrorFormat("layerDictionary did not contains layer == {0}", layer.ToString());
                return null;
            }
            
        }
    }
}
