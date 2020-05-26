using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Manager
{
    // Manager of the Finite State Machine 
    public class FsmManager : MonoSingleton<FsmManager>
    {
        private IFsmState _currentEvent;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }
        public void ChangeEvent(IFsmState newState)
        {
            _currentEvent?.Exit();
            _currentEvent = newState;
            _currentEvent.Start();
        }

        // Update is called once per frame
        void Update() => _currentEvent.Update();
        
    }
}