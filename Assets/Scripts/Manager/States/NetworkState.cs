using System.Collections;
using UnityEngine.Networking;
using Utility;

namespace Manager.States
{
    public class NetworkState : IFsmState
    {
        public void Start()
        {
            MonoUtils.Instance.StartCoroutine(GetFiles());
        }

        // Update is called once per frame
        public void Update()
        {

        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        private IEnumerator GetFiles()
        {
            var www = new UnityWebRequest(Settings.UrlDownloadData)
            {
                downloadHandler = new DownloadHandlerBuffer()
            };

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                GameEvents.Instance.ErrorMessage(www.error);
            }
            else
            {
                var objDownloadData = Utils.ConvertToObjDownloadData(www.downloadHandler.text);
                GameEvents.Instance.OnDownloadDataFinished(objDownloadData);
            }
        }

        
    }
}
