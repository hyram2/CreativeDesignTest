using System.Collections;
using System.Collections.Generic;
using System.IO;
using Model;
using Unity.Collections;
using UnityEngine;
using Utility;

namespace Manager.FSMStates
{
    public class LoadFileSystem : IFsmState
    {
        private string _dirPath;
        public void Start()
        {
            _dirPath = Application.dataPath + Settings.LocalSaveDataPath;
            if (Directory.Exists(_dirPath))
            {
                MonoUtils.Instance.StartCoroutine(LoadFilesData());
            }
            else
            {
                GameEvents.OnFilesOpFinished();
            }
        }
        
        public void Exit()
        {
        }

        IEnumerator LoadFilesData()
        {
            var info = new DirectoryInfo(_dirPath);
            var fileInfo = info.GetFiles();
            foreach (var file in fileInfo)
            {
                if (!file.FullName.Contains(".json"))
                    continue;
                Debug.Log(file.FullName);
                var data = File.ReadAllText(file.FullName);
                var objDownloadData = MonoUtils.ConvertToObjDownloadData(data);
                objDownloadData.Name = file.Name;
                GameEvents.OnDownloadDataFinished(objDownloadData);
            }
            yield return null;
            GameEvents.OnFilesOpFinished();

        }
    }
}
