using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using Manager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace View
{
    public class GameMenuManager : MonoBehaviour
    {
        private GameManager _manager;
        
        public Action<bool> onSelectChange;
        public Action onAnySelected;
        
        public GameObject objPanel;
        public MenuObjView objBtnPrefab;
        public bool selectMode;
        public GameObject[] deactiveOnSelectMode;
        
        public Text log;
        void Start()
        {
            _manager = GameManager.Instance;
            GameEvents.OnSceneObjAdd += LoadObjsMenu;
            GameEvents.OnSceneObjAddRange += LoadRangeObjsMenu;
            GameEvents.OnFilesOpFinished += OnOpCallBack;
            LoadRangeObjsMenu(_manager.objsScene);
        }

        public void OnChangeSelectMode(Toggle objRef)
        {
            selectMode = objRef.isOn;
            _manager.objsSelected.Clear();
            onSelectChange?.Invoke(objRef.isOn);
            foreach (var gameObj in deactiveOnSelectMode)
            {
                gameObj.SetActive(!objRef.isOn);
            }

            if (objRef.isOn)
            {
                Rotate();
            }
        }
        
        private void LoadRangeObjsMenu(List<SceneObj> obj)
        {
            obj.ForEach(LoadObjsMenu);
        }

        private void LoadObjsMenu(SceneObj obj)
        {
            var button = Instantiate(objBtnPrefab, objPanel.transform, false);
            button.menuManager = this;
            button.gameObject.SetActive(true);
            onSelectChange+=button.OnChangeSelectMode;
            var objTexture = _manager.objsTextures.First(y => y.Name == obj.name).Textures;
            var objColors = new Color[objTexture.Length];
            
            for (var i = 0; i < objTexture.Length; i++)
            {
                var value = Random.Range(0, 1f);
                var color = Color.HSVToRGB(value, 1, 1);
                objColors[i] = color;
            }

            button.text.text = obj.name;
            button.objGuidRef = obj.guid;
            button.LoadTexture(objTexture);
            button.LoadColors(objColors);
        }


        //Target States
        public void Move()
        {
            log.text = "Move Mode";
            _manager.Move();
        }

        public void Rotate()
        {
            log.text = "Rotate Mode";
            if (selectMode)
                _manager.RotateAll();
            else
                _manager.Rotate();
        }
        
        public void Scale()
        {
            log.text = "Scale Mode";
            if(selectMode)
                _manager.ScaleAll();
            else
                _manager.Scale();
        }

        public void Duplicate()
        {
            log.text = "Duplicating Mode";
            _manager.Duplicate();
        }

        public void SaveScene()
        {
            log.text = "Saving...";
            _manager.SaveScene();
        }

        public void OnOpCallBack()
        {
            log.text = "Done.";
        }

        public void ClearLog()
        {
            log.text = "";
        }
    }
}
