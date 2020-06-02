using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class ScaleOnceState : ICommandState
    {
        private GameObject _gameObject;
        private KeyCode? _actualAxis;

        public void OnMouseDown(SceneObj obj)
        {
            _gameObject = obj.gameObject;
        }
        
        public void OnMouseDrag()
        {
            var xAxis = Input.GetAxis("Mouse X")*0.5f;
            var yAxis = Input.GetAxis("Mouse Y")*0.5f;

            var actualScale =_gameObject.transform.localScale;
            Debug.Log("xAxis " + xAxis);

            switch (_actualAxis)
            {
                case KeyCode.X:
                        actualScale.x += xAxis;
                        actualScale.x += yAxis;
                    break;
                case KeyCode.Y:
                        actualScale.y += xAxis;
                        actualScale.y += yAxis;
                    break;
                case KeyCode.Z:
                        actualScale.z += xAxis;
                        actualScale.z += yAxis;
                    break;
                case null:
                        actualScale += new Vector3(yAxis, yAxis, yAxis);
                        actualScale += new Vector3(xAxis,xAxis,xAxis);
                    break;
            }

            if (actualScale.x < 0.05f) actualScale.x = 0.05f;
            if (actualScale.y < 0.05f) actualScale.y = 0.05f;
            if (actualScale.z < 0.05f) actualScale.z = 0.05f;
            _gameObject.transform.localScale = actualScale;
        }

        public void OnStateStart()
        {
        }

        public void OnStateExit()
        {
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

        // Useless here, but the interface was generic
        public List<SceneObj> SceneObjs { get; set; }
    }
}
