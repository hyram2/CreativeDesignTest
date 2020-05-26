using UnityEngine;
using Utility;

namespace Utility
{
    /// <summary>
    /// Inherit from this base class to create a singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;

        /// <summary>
        /// Access singleton instance through this propriety. Case That does not exist create a new one.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = new T();
                
                return _instance;
            }
        }

    }
}