using UnityEngine;

namespace SingletonPattern
{
    public class MonoSingleton<Type> : MonoBehaviour where Type : MonoBehaviour
    {
        protected static Type _instance;

        public static Type Instance
        {
            get
            {
                if (null == _instance)
                    throw new System.Exception("An instance of " + typeof(Type) + " is needed in the scene, but there is none.");

                return _instance;
            }
        }

        protected void InitializeSingleton()
        {
            if (null == _instance)
                _instance = gameObject.GetComponent<Type>();

            else if (!IsThisTheInstance())
                Destroy(gameObject);
        }

        protected void PassTroughScenes()
        {
            if (IsThisTheInstance())
                DontDestroyOnLoad(gameObject);
            else
                Destroy(gameObject);
        }

        protected bool IsThisTheInstance()
        {
            if (_instance != this)
                return false;
            else
                return true;
        }
    }
}