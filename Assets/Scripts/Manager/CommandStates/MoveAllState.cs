using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class MoveAllState : ICommandState
    {
        public List<SceneObj> SceneObjs { get; set; }
        //ref to calc
        private GameObject _gameObject;
        private Vector3 _offset;
        private float _zCoord;
    
        private Vector3 GetMouseAsWorldPoint()
        {
            var mousePoint = Input.mousePosition;
            mousePoint.z = _zCoord;
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        public void OnMouseDown(SceneObj obj)
        {
            _gameObject = obj.gameObject;
            _zCoord = Camera.main.WorldToScreenPoint(_gameObject.transform.position).z;
            _offset = _gameObject.transform.position - GetMouseAsWorldPoint();
        }
    
        public void OnMouseDrag()
        {
            SceneObjs.ForEach(x=> x.transform.position = GetMouseAsWorldPoint() + _offset);
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
    }
}
