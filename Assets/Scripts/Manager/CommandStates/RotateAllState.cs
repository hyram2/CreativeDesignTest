using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class RotateAllState : ICommandState
    {
        
        public List<SceneObj> SceneObjs { get; set; }
        private KeyCode? _actualAxis;
        public void OnMouseDrag()
        {
            var xAxis = Input.GetAxis("Mouse X") * 100f * Mathf.Deg2Rad;
            var yAxis = Input.GetAxis("Mouse Y") * 100f * Mathf.Deg2Rad;
            switch (_actualAxis)
            {
                case null:
                {
                    SceneObjs.ForEach(x =>
                    {
                        x.transform.Rotate(Vector3.up, xAxis);
                        x.transform.Rotate(Vector3.right, yAxis);
                    });
                    break;
                }
                case KeyCode.X:
                    SceneObjs.ForEach(x =>
                    {
                        x.transform.Rotate(Vector3.right, xAxis);
                        x.transform.Rotate(Vector3.right, yAxis);
                    });
                    break;
                case KeyCode.Y:
                    SceneObjs.ForEach(x=>
                    {
                        x.transform.Rotate(Vector3.up, xAxis);
                        x.transform.Rotate(Vector3.up, yAxis);
                    });
                    break;
                case KeyCode.Z:
                    SceneObjs.ForEach(x=>
                    {
                        x.transform.Rotate(Vector3.forward, xAxis);
                        x.transform.Rotate(Vector3.forward, yAxis);
                    });
                    break;
            }
        }
        public void OnStateStart() { }

        public void OnStateExit() { }
        public void OnMouseDown(SceneObj obj) { }

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
                default:
                    break;
            }
        }
    }
}
