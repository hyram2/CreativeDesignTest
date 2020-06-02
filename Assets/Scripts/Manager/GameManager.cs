using System;
using System.Collections.Generic;
using System.Linq;
using Manager.CommandStates;
using Manager.FSMStates;
using Model;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;
using static GameEvents;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public List<SceneModel> scenes = new List<SceneModel>();
        public SceneModel sceneToLoad;
        public List<SceneObj> objsScene = new List<SceneObj>();
        public List<ObjTexture> objsTextures = new List<ObjTexture>();
        public List<SceneObj> objsSelected = new List<SceneObj>();

        private void OnEnable()
        {
            OnDownloadDataFinished += OnGetData;
            ErrorMessage += OnGetError;
            OnSceneObjAdd += ObjSceneAdd;
            OnSceneObjAddRange += ObjSceneAddRange;
        }

        private void ObjSceneAdd(SceneObj obj)
        {
            objsScene.Add(obj);
        }

        private void ObjSceneAddRange(List<SceneObj> obj)
        {
            objsScene.AddRange(obj);
        }

        private void OnDisable()
        {
            if (OnDownloadDataFinished != null) OnDownloadDataFinished -= OnGetData;
            if (ErrorMessage != null) ErrorMessage -= OnGetError;
            if (OnSceneObjAdd != null) OnSceneObjAdd -= ObjSceneAdd;
            if (OnSceneObjAddRange != null) OnSceneObjAddRange -= ObjSceneAddRange;
        }

        void OnGetData(SceneModel model)
        {
            scenes.Add(model);
            if (sceneToLoad == null)
                sceneToLoad = model;
        }

        public void StartLoadObjs()
        {
            FsmManager.Instance.ChangeState<LoadSceneState>();
        }

        public void SaveScene()
        {
            FsmManager.Instance.ChangeState<SaveFileSystem>();
        }

        public void SelectObj(Guid objGuid)
        {
            print(objGuid);
            var sceneObj = objsScene.First(x => x.guid == objGuid);
            if (sceneObj != null)
                objsSelected.Add(sceneObj);
            CommandManager.Instance.OnChangeSelectedGroup(objsSelected);
        }

        public void UnSelectObject(Guid objGuid)
        {
            var objToRemove = objsSelected.First(x => x.guid == objGuid);
            if (objToRemove != null)
                objsSelected.Remove(objToRemove);
            CommandManager.Instance.OnChangeSelectedGroup(objsSelected);
        }

        //Target States
        public void Move() => CommandManager.Instance.ChangeState<MoveOnceState>();
        public void Rotate() => CommandManager.Instance.ChangeState<RotateOnceState>();
        public void Scale() => CommandManager.Instance.ChangeState<ScaleOnceState>();
        public void Duplicate() => CommandManager.Instance.ChangeState<DuplicateOnceState>();
//        public void VisualAspects() => CommandManager.Instance.ChangeState<VisualOnceState>();
        //Mass States
//        public void MoveAll() => CommandManager.Instance.ChangeState<MoveAllState>(objsSelected);
        public void RotateAll() => CommandManager.Instance.ChangeState<RotateAllState>(objsSelected);
        public void ScaleAll() => CommandManager.Instance.ChangeState<ScaleAllState>(objsSelected);
//        public void DuplicateAll() => CommandManager.Instance.ChangeState<DuplicateAllState>(objsSelected);
        public void VisualAspectsAll() => CommandManager.Instance.ChangeState<VisualAllState>(objsSelected);

        void OnGetError(string message) => print(message);
    }
}
