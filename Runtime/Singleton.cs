using System;

namespace SingletonPattern
{
    public class Singleton<T> where T : class, new()
    {
        protected Singleton() { }

        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance { get { return _instance.Value; } }
    }
}