using System;
using UnityEngine;

namespace AsFramework.Utils
{
    /// <summary>
    /// 需要使用Unity生命周期的单例模式
    /// </summary>
    public abstract class MonoSingleton <T> : MonoBehaviour, ISingleton where T : MonoSingleton<T>
    {
        protected static T _instance = null;
        private static bool _onApplicationQuit = false;

        public static T Instance
        {
            get
            {
                if (_instance == null && !_onApplicationQuit)
                {
                    _instance = MonoSingletonCreator.CreateMonoSingleton<T>();
                }
                return _instance;
            }
        }


        public virtual void OnSingletonInit()
        { 
            
        }

        public static bool IsApplicationQuit
        {
            get
            {
                return _onApplicationQuit;
                
            }
        }

        protected virtual void OnApplicationQuit()
        {
            _onApplicationQuit = true;
            if (_instance == null) return;
            Destroy(_instance.gameObject);
            _instance = null;
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}
