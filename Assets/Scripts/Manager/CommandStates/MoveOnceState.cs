using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class MoveOnceState : ICommandState
    {

        private GameObject _gameObject;
        private Vector3 mOffset;
        private float mZCoord;
    
        private Vector3 GetMouseAsWorldPoint()
        {
            //todo
            // Pixel coordinates of mouse (x,y)

            Vector3 mousePoint = Input.mousePosition;


            // z coordinate of game object on screen

            mousePoint.z = mZCoord;


            // Convert it to world points

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        
        public void OnMouseDown(SceneObj obj)
        {
            _gameObject = obj.gameObject;
            mZCoord = Camera.main.WorldToScreenPoint(obj.transform.position).z;
            mOffset = _gameObject.transform.position - GetMouseAsWorldPoint();
        }
    
        public void OnMouseDrag()
        {
            _gameObject.transform.position = GetMouseAsWorldPoint() + mOffset;
        }

        public void OnStateStart()
        {
        }

        public void OnStateExit()
        {
        }

        public void OnKeyEvent(KeyCode keyCode)
        {
        }

        // Useless here, but the interface was generic
        public List<SceneObj> SceneObjs { get; set; }
    }
}
