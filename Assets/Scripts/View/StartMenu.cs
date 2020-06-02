using System;
using Manager;
using Model;
using UnityEngine;
using UnityEngine.UI;
using static GameEvents;

namespace View
{
    public class StartMenu : MonoBehaviour
    {
        public Image imageLoad;
        public GameObject panel;
        public Text log;

        public Button buttonRef;
        // Start is called before the first frame update
        void Start()
        {
            OnStartLoadScene += StartLoad;
            OnLoadingSceneStatus += OnLoadSceneStatus;
            ErrorMessage += ChangeLog;
            OnDownloadDataFinished += LoadMenuData;
        }

        private void LoadMenuData(SceneModel model)
        {
            var button = Instantiate(buttonRef, panel.transform, false) as Button;
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<Text>().text = model.Name;
            button.onClick.AddListener(() =>
            {
                GameManager.Instance.sceneToLoad = model;
                GameManager.Instance.StartLoadObjs();
                imageLoad.gameObject.SetActive(true);
            });
        }

        void ChangeLog(string text)
        {
            log.text = text;
        }

        void StartLoad()
        {
            panel.SetActive(false);
            imageLoad.gameObject.SetActive(true);
        }

        void OnLoadSceneStatus(float value)
        {
            imageLoad.fillAmount = value;
        }

        private void OnDestroy()
        {
            if (OnStartLoadScene != null) OnStartLoadScene -= StartLoad;
            if (OnLoadingSceneStatus != null) OnLoadingSceneStatus -= OnLoadSceneStatus;
            if (ErrorMessage != null) ErrorMessage -= ChangeLog;
            if (OnDownloadDataFinished != null) OnDownloadDataFinished -= LoadMenuData;
        }
    }
}
