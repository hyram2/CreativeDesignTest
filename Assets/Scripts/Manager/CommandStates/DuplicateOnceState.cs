using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class DuplicateOnceState : ICommandState
    {
    
        public void OnMouseDown(SceneObj obj)
        {
            var newObj = Object.Instantiate(obj);
            newObj.name = obj.name;
            newObj.transform.position += (newObj.transform.localScale.magnitude*2 * Vector3.back );
            GameEvents.OnSceneObjAdd(newObj);
        }

        public void OnMouseDrag() {}

        public void OnStateStart() {}

        public void OnStateExit() {}

        public void OnKeyEvent(KeyCode keyCode) {}
        public List<SceneObj> SceneObjs { get; set; }
    }
}
