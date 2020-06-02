using System;
using Manager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace View
{
    //todo: Refactor
    public class MenuObjView : MonoBehaviour
    {
        private GameManager _manager;
        public GameObject colorsView;
        public GameObject texturesView;
        public Button self;
        public Text text;
        public bool isSelected;
        private bool _selectMode;
        public Guid objGuidRef;
        [FormerlySerializedAs("menu")] public GameMenuManager menuManager;


        void Start()
        {
            _manager = GameManager.Instance;
            self.onClick.AddListener(OnClick);
            menuManager.onAnySelected += DeactiveSelf;
        }

        public void LoadColors(Color[] colors)
        {
            var btns = colorsView.GetComponentsInChildren<Button>();
            for (var i = 0; i < btns.Length; i++)
            {
                var btn = btns[i];
                var color = colors[i];
                btn.image.color = color;
                btn.onClick.AddListener(() => { GameEvents.OnChangeColor(color); });
            }
        }

        public void LoadTexture(Texture[] textures)
        {
            var btns = texturesView.GetComponentsInChildren<Button>();
            for (var i = 0; i < btns.Length; i++)
            {
                var texture = textures[i];
                var btn = btns[i];
                btn.image.sprite = Sprite.Create((Texture2D) texture, new Rect(0, 0, 50, 50), Vector2.down);
                btn.onClick.AddListener(() => { GameEvents.OnChangeTexture(texture); });
            }
        }

        private void OnClick()
        {
            isSelected = !isSelected;

            
            if (_selectMode)
            {
                self.image.color = isSelected ? Color.gray : Color.white;
            }
            else
            {
                _manager.objsSelected.Clear();
                self.image.color = Color.white;
                _manager.VisualAspectsAll();
                menuManager.log.text = "Change Visual Mode";
                menuManager.onAnySelected();
                colorsView.SetActive(isSelected);
                texturesView.SetActive(isSelected);
            }
            if (isSelected)
            {
                _manager.SelectObj(objGuidRef);
            }
        }
        
        public void OnChangeSelectMode(bool value)
        {
            _selectMode = value;
            DeactiveSelf();
        }
        
        
        private void DeactiveSelf()
        {
            self.image.color = Color.white;
            colorsView.SetActive(false);
            texturesView.SetActive(false);
        }
    }
}
