using System;
using System.Collections.Generic;
using Manager.CommandStates;
using UnityEngine;
using Utility;

namespace Manager
{
    public class CommandManager : MonoSingleton<CommandManager>//game controller
    {
        private ICommandState  _currentEvent;
        
        // Start is called before the first frame update
        void Start()
        {
            ChangeState<MoveOnceState>();
        }
        
        private void OnEnable()
        {
             GameEvents.OnMouseDown += OnMouseDown;
             GameEvents.OnSimpleDrag += OnMouseDrag;
             
             
        }
        private void OnDisable()
        {
            if (GameEvents.OnMouseDown != null) GameEvents.OnMouseDown -= OnMouseDown;
            if (GameEvents.OnSimpleDrag != null) GameEvents.OnSimpleDrag -= OnMouseDrag;
        }

        public void ChangeState(ICommandState newState)  
        {
            _currentEvent?.OnStateExit();
            _currentEvent = newState;
            _currentEvent.OnStateStart();
        }

        public void ChangeState<T>(List<SceneObj> objs = null) where T : ICommandState, new()
        {
            _currentEvent?.OnStateExit();
            _currentEvent = new T {SceneObjs = objs};
            _currentEvent.OnStateStart();
        }
        
        public void ChangeSelectionObjects(List<SceneObj> objs) => _currentEvent.SceneObjs = objs;
        private void OnMouseDown(SceneObj obj) => _currentEvent.OnMouseDown(obj);
        private void OnMouseDrag() => _currentEvent.OnMouseDrag();
        private void OnKeyEvent(KeyCode keyCode) => _currentEvent.OnKeyEvent(keyCode);
        public void OnChangeSelectedGroup(List<SceneObj> objs)
        {
            print("Allah!");
            _currentEvent.SceneObjs = objs;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) OnKeyEvent(KeyCode.X);

            if (Input.GetKeyDown(KeyCode.Y)) OnKeyEvent(KeyCode.Y);

            if (Input.GetKeyDown(KeyCode.Z)) OnKeyEvent(KeyCode.Z);

            if (Input.GetKeyDown(KeyCode.N)) OnKeyEvent(KeyCode.N);
            
            if (Input.GetKeyDown(KeyCode.Escape)) OnKeyEvent(KeyCode.Escape);
        }
    }
}
