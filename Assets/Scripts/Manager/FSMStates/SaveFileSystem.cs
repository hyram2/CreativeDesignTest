using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Model;
using UnityEngine;
using Utility;

namespace Manager.FSMStates
{
    public class SaveFileSystem : IFsmState
    {
        private string _dirPath;
        public void Start()
        {
            _dirPath = Application.dataPath + Settings.LocalSaveDataPath;
            if (Directory.Exists(_dirPath))
            {
                GameEvents.OnFilesOpFinished();
            }
            else
            {
                Directory.CreateDirectory(_dirPath);
            }
            MonoUtils.Instance.StartCoroutine(SaveFilesData());
        }
        
        public void Exit()
        {
        }

        IEnumerator SaveFilesData()
        {
            Debug.Log("Saving...");
            var objsModel = GameManager.Instance.objsScene;
            var models = new List<Model.Model>();
            objsModel.ForEach(x =>
            {
                models.Add(new Model.Model(x));
            });
            var newScene = new SceneModel()
            {
                Models = models
            };
            var now = DateTime.Now;
            var fileName = "save_"+now.Year+now.Month+now.Day+now.Hour+now.Millisecond;
            var jsonFormatScene = new SceneData(newScene);
            var json = MonoUtils.ConvertToJsonData(jsonFormatScene);
            
            Debug.Log("Saving... Dir: "+_dirPath+@"/"+fileName+".json");
            
            //write string to file
            System.IO.File.WriteAllText(_dirPath+@"/"+fileName+".json", json);
            
            GameEvents.OnFilesOpFinished();
            yield return null;
        }
    }
}
