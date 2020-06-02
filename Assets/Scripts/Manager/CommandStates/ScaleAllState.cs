using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class ScaleAllState : ICommandState
    {
        
        private KeyCode? _actualAxis;
        public List<SceneObj> SceneObjs { get; set; }
        
        public void OnMouseDrag()
        {
            Debug.Log(SceneObjs.Count);
            var dif = (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y"))*0.5f;

            switch (_actualAxis)
            {
                case KeyCode.X:
                    SceneObjs.ForEach(x =>
                    {
                        var actualScale = x.transform.localScale;
                        actualScale.x += dif;
                        if (actualScale.x <= 0.05f) actualScale.x = 0.05f;
                        x.transform.localScale = actualScale;
                    });
                    break;
                case KeyCode.Y:
                    SceneObjs.ForEach(x =>
                    {
                        var actualScale = x.transform.localScale;
                        actualScale.y += dif;
                        if (actualScale.y <= 0.05f) actualScale.y = 0.05f;
                        x.transform.localScale = actualScale;
                    });
                    break;
                case KeyCode.Z:
                    SceneObjs.ForEach(x =>
                    {
                        var actualScale = x.transform.localScale;
                        actualScale.z += dif;
                        if (actualScale.z <= 0.05f) actualScale.z = 0.05f;
                        x.transform.localScale = actualScale;
                    });
                    break;
                case null:
                    var tempAdd = new Vector3(dif,dif,dif);
                    SceneObjs.ForEach(x =>
                    {
                        var actualScale = x.transform.localScale;

                        actualScale += tempAdd; 
                        if (actualScale.x <= 0.05f) actualScale.x = 0.05f;
                        if (actualScale.y <= 0.05f) actualScale.y = 0.05f;
                        if (actualScale.z <= 0.05f) actualScale.z = 0.05f;
                        x.transform.localScale = actualScale;
                    });
                    break;
            }
        }

        public void OnKeyEvent(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.X:
                case KeyCode.Y:
                case KeyCode.Z:
                    _actualAxis = keyCode;
                    break;
                case KeyCode.N:
                case KeyCode.Escape:
                    _actualAxis = null;
                    break;
            }
        }
        public void OnStateStart() {}
        public void OnStateExit() {}
        public void OnMouseDown(SceneObj obj) {}
    }
}

