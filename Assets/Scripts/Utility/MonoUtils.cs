using System;
using System.Collections;
using Model;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    //This class is a reference for the Mono Methods
    public class MonoUtils : MonoSingleton<MonoUtils>
    {
        public static SceneModel ConvertToObjDownloadData(string text)
        {
            var result = new SceneModel();
            
            try
            {
                var dataObj =  JsonConvert.DeserializeObject<SceneData>(text);
                result = new SceneModel(dataObj);
            }
            catch (Exception e)
            {
                GameEvents.ErrorMessage(e.Message);
            }
            
            return result;
        }

        public static string ConvertToJsonData(SceneData data)
        {
            
            string result = "";
            
            try
            {
                result = JsonConvert.SerializeObject(data);
            }
            catch (Exception e)
            {
                GameEvents.ErrorMessage(e.Message);
            }
            
            return result;
        }
    }
}
