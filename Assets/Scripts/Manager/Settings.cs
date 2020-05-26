using UnityEngine;
using Utility;

namespace Manager
{
    public class Settings : MonoSingleton<Settings>
    {
        public const string UrlDownloadData = "https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json";
        public const string GameSaveLocation = "";
    }
}
