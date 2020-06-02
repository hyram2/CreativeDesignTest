using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class VisualOnceState : ICommandState
    {
        public List<SceneObj> SceneObjs { get; set; }
        private GameObject _gameObject;
        private Color _actualColorSelected = Color.white;
        private Texture _actualTextureSelected;
        
        
        public void OnStateStart()
        {
            GameEvents.OnChangeColor += OnChangeColor;
            GameEvents.OnChangeTexture += OnChangeTexture;
        }

        public void OnStateExit()
        {
            if (GameEvents.OnChangeColor != null) GameEvents.OnChangeColor -= OnChangeColor;
            if (GameEvents.OnChangeTexture != null) GameEvents.OnChangeTexture -= OnChangeTexture;
        }

        public void OnMouseDown(SceneObj obj)
        {
            _gameObject = obj.gameObject;
            if (_actualTextureSelected != null)
                ChangeTexture(_actualTextureSelected);
            ChangeColor(_actualColorSelected);
        }

        private void OnChangeColor(Color color)
        {
            _actualColorSelected = color;
            if (_gameObject == null)
                return;
            ChangeColor(color);
        }
    
        private void OnChangeTexture(Texture texture)
        {
            _actualTextureSelected = texture;
            if (_gameObject == null)
                return;
            ChangeTexture(texture);
        }

        private void ChangeColor(Color color)
        {
            var renderer = _gameObject.GetComponent<Renderer>();
            renderer.material.color = color;
        }

        private void ChangeTexture(Texture texture)
        {
            var renderer = _gameObject.GetComponent<Renderer>();
            renderer.material.mainTexture = texture;
        }

        public void OnKeyEvent(KeyCode keyCode) {}
        public void OnMouseDrag() {}
    
    }
}
