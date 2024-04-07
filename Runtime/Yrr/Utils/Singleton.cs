using UnityEngine;


namespace Yrr.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static bool isApplicationQuitting;
        private static T _instance;


        public static T Instance
        {
            get
            {
                if (isApplicationQuitting)
                    return null;

                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var singleton = new GameObject(typeof(T).ToString());
                        _instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }

                return _instance;
            }
        }

        protected virtual void Initialize() { }


        public virtual void OnDestroy()
        {
            isApplicationQuitting = true;
        }
    }
}