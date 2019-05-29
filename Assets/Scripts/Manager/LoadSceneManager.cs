using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Manager
{
    public class LoadSceneManager : SingletonBase<LoadSceneManager>   
    {
        private AsyncOperation asyncOperation;

        public void AllowSwitchScene()
        {
            asyncOperation.allowSceneActivation = true;
        }

        public float Progress
        {
            get { return asyncOperation.progress; }
        }

        public IEnumerator LoadSceneAsync(string name)
        {
            asyncOperation = SceneManager.LoadSceneAsync(name);
            asyncOperation.allowSceneActivation = false;
            yield return asyncOperation;  
        }
    }
}
