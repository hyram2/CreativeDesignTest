using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Manager.CommandStates
{
    public class VisualAllState : ICommandState
    {
        public List<SceneObj> SceneObjs { get; set; }
        
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


        private void OnChangeColor(Color color)
        {
            SceneObjs.ForEach(x=> x.renderer.material.color = color);
        }
    
        private void OnChangeTexture(Texture texture)
        {
            if (!SceneObjs.Any())
                return;
            ChangeTexture(texture);
        }


        private void ChangeTexture(Texture texture)
        {
            SceneObjs.ForEach(x=> x.renderer.material.mainTexture = texture);
            
        }

        public void OnMouseDrag() {}
        public void OnMouseDown(SceneObj obj) {}
        public void OnKeyEvent(KeyCode keyCode) {}
    }
}
