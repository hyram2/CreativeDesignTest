using UnityEngine;

namespace Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                // Search for existing instance.
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance != null) return _instance;
                
                // Create new instance if one doesn't already exist.
                var singletonObject = new GameObject();
                _instance = singletonObject.AddComponent<T>();
                singletonObject.name = typeof(T)+ "(MonoSingleton Instanced)";
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this as T;
            if (_instance != this)
            {
                Destroy(this);
                return;
            }
            // Make instance persistent.
            DontDestroyOnLoad(this as T);
        }
    }
}