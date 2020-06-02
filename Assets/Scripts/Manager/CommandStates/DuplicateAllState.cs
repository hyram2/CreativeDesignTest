using System.Collections.Generic;
using UnityEngine;

namespace Manager.CommandStates
{
    public class DuplicateAllState : ICommandState
    {
        public List<SceneObj> SceneObjs { get; set; }
    
        public void OnStateStart()
        {
            GameEvents.OnDuplicate += OnDuplicate;
        }

        public void OnStateExit()
        {
            if (GameEvents.OnDuplicate != null) GameEvents.OnDuplicate -= OnDuplicate;
        }
        
        private void OnDuplicate()
        {
            var tempNewObjs = new List<SceneObj>();
            SceneObjs.ForEach(x =>
            {
                var newObj = Object.Instantiate(x);
                newObj.name = x.name;
                newObj.transform.position += (newObj.transform.localScale.magnitude*2 * Vector3.back);
                tempNewObjs.Add(newObj);
            });
           GameEvents.OnSceneObjAddRange(tempNewObjs);
        }
        
        public void OnMouseDown(SceneObj obj){}

        public void OnMouseDrag(){}

        public void OnKeyEvent(KeyCode keyCode){}
    }
}
