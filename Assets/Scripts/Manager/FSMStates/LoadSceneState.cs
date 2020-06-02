using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Manager.FSMStates
{
    public class LoadSceneState : IFsmState
    {
        public void Start()
        {
            MonoUtils.Instance.StartCoroutine(LoadScene());
        }


        private IEnumerator LoadScene()
        {
            var loading = SceneManager.LoadSceneAsync("AppScene");
            while (!loading.isDone)
            {
                GameEvents.OnLoadingSceneStatus(loading.progress);
                yield return null;
            }
            
        }

        public void Exit()
        {
        }
    }
}