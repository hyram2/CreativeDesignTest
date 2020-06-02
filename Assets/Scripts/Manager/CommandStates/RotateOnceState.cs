using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class RotateOnceState : ICommandState
    {
        private GameObject _gameObject;
        private KeyCode? _actualAxis;

        public void OnMouseDown(SceneObj obj)
        {
            _gameObject = obj.gameObject;
        }
        
        public void OnMouseDrag()
        {
            Debug.Log("mousedrag");

            var xAxis = Input.GetAxis("Mouse X") * 100f * Mathf.Deg2Rad;
            float yAxis = Input.GetAxis("Mouse Y") * 100f * Mathf.Deg2Rad;
            switch (_actualAxis)
            {
                case null:
                {
                    _gameObject.transform.Rotate(Vector3.up, xAxis);
                    _gameObject.transform.Rotate(Vector3.right, yAxis);
                    break;
                }
                case KeyCode.X:
                    _gameObject.transform.Rotate(Vector3.right, xAxis);
                    _gameObject.transform.Rotate(Vector3.right, yAxis);
                    
                    break;
                case KeyCode.Y:
                    _gameObject.transform.Rotate(Vector3.up, xAxis);
                    _gameObject.transform.Rotate(Vector3.up, yAxis);
                    break;
                case KeyCode.Z:
                    _gameObject.transform.Rotate(Vector3.forward, xAxis);
                    _gameObject.transform.Rotate(Vector3.forward, yAxis);
                    break;
                default:
                    break;
            }
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