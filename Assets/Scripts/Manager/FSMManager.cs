using System;
using System.Collections;
using System.Collections.Generic;
using Manager.FSMStates;
using UnityEngine;
using Utility;

namespace Manager
{
    // Manager of the Finite State Machine 
    public class FsmManager : MonoSingleton<FsmManager>
    {
        private IFsmState _currentEvent;

        private bool _isNetworkDownloaded;
        // Start is called before the first frame update
        void Start()
        {
            ChangeState(new NetworkState());
        }

        public void OnEnable()
        {
            GameEvents.OnFilesOpFinished += OnOpFinished;
        }
        
        public void OnDisable()
        {
            if (GameEvents.OnFilesOpFinished != null) GameEvents.OnFilesOpFinished -= OnOpFinished;
        }

        public void ChangeState(IFsmState newState)
        {
            _currentEvent?.Exit();
            _currentEvent = newState;
            _currentEvent.Start();
        }
        public void ChangeState<T>() where T : IFsmState, new()
        {
            _currentEvent?.Exit();
            _currentEvent = new T();
            _currentEvent.Start();
        }

        public void OnOpFinished()
        {
            if (_isNetworkDownloaded)
            {
                ChangeState(new IdleState());
                return;
            }
            _isNetworkDownloaded = true;
            ChangeState(new LoadFileSystem());
        }
    }
}