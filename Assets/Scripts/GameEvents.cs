using Model;
using Utility;

public class GameEvents : Singleton<GameEvents>
{
    public delegate void MessageEvent(string message);
    public delegate void DownloadDataEvent(ObjDownloadData data);

    public MessageEvent ErrorMessage;
    public DownloadDataEvent OnDownloadDataFinished;
}