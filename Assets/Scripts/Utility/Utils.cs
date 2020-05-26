using System;
using Manager;
using Model;
using Newtonsoft.Json;

namespace Utility
{
    public class Utils
    {
        public static ObjDownloadData ConvertToObjDownloadData(string text)
        {
            var result = new ObjDownloadData();
            
            try
            {
                result = JsonConvert.DeserializeObject<ObjDownloadData>(text);
            }
            catch (Exception e)
            {
                GameEvents.Instance.ErrorMessage(e.Message);
            }
            
            return result;
        }
    }
}