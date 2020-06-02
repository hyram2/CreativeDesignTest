using System.Collections.Generic;
using Manager;
using Model;
using UnityEngine;
using Utility;

public static class GameEvents
{
    public delegate void MessageEvent(string message);
    public delegate void DownloadDataEvent(SceneModel model);
    public delegate void SimpleEvent();
    public delegate void FloatEvent(float value);

    public delegate void ChangeColor(Color color);
    public delegate void ChangeTexture(Texture texture);
    public delegate void SceneObjEvent(SceneObj obj);
    public delegate void SceneObjRangeEvent(List<SceneObj> obj);
    
    public static MessageEvent ErrorMessage;
    public static DownloadDataEvent OnDownloadDataFinished;
    public static SimpleEvent OnFilesOpFinished;
    
    public static SimpleEvent OnSimpleDrag;
    public static SceneObjEvent OnMouseDown;
    public static ChangeColor OnChangeColor;
    public static ChangeTexture OnChangeTexture;
    public static SimpleEvent OnDuplicate;
    public static SceneObjEvent OnSceneObjAdd;
    public static SceneObjRangeEvent OnSceneObjAddRange;

    public static SimpleEvent OnStartLoadScene;
    public static FloatEvent OnLoadingSceneStatus;
    public static SimpleEvent OnSceneIsLoaded;
    
}