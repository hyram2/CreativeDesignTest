using System.Collections;
using UnityEngine;
using Utility;

namespace Manager.FSMStates
{
    public class NetworkState : IFsmState
    {
        public void Start()
        {
            MonoUtils.Instance.StartCoroutine(GetNetworkFiles());
        }

        public void Exit()
        {
        }

        private IEnumerator GetNetworkFiles()
        {
            //todo: change to UnityWebRequest 
            var www = new WWW(Settings.UrlDownloadData);
            yield return www;
            var jsonData = "";
            if (string.IsNullOrEmpty(www.error)) { 
                jsonData = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);  // Skip thr first 3 bytes (i.e. the UTF8 BOM)
                // JSONObject works now
                var objDownloadData = MonoUtils.ConvertToObjDownloadData(jsonData);
                
                objDownloadData.Name = "Network Scene";
                GameEvents.OnDownloadDataFinished(objDownloadData);
            } else{ 
                GameEvents.ErrorMessage(www.error);
            }

            GameEvents.OnFilesOpFinished();
        }
    }
}
