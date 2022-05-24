﻿using UnityEngine;

namespace AsFramework.Utils.Singleton.Example
{
    public class PropertyExample : MonoBehaviour
    {
        // 定义基类
        public class BaseManager : MonoBehaviour
        {
        }

        // 定义实现类
        public class GameManager : BaseManager, ISingleton
        {
            public static GameManager Instance
            {
                get { return MonoSingletonProperty<GameManager>.Instance; }
            }

            public void OnSingletonInit()
            {
                Debug.Log("GameManager Init");
            }
        }

        // 基类
        public class BaseService
        {
        }

        public class BluetoothService : BaseService, ISingleton
        {
            private BluetoothService()
            {
            }

            public static BluetoothService Instance
            {
                get { return SingletonProperty<BluetoothService>.Instance; }
            }

            public void OnSingletonInit()
            {
                Debug.Log("BluetoothService Init");
            }
        }

        void Start()
        {
            var instance1 = GameManager.Instance;
            var instance2 = GameManager.Instance;

            Debug.Log(instance1.GetHashCode() == instance2.GetHashCode());

            var service1 = BluetoothService.Instance;
            var service2 = BluetoothService.Instance;

            Debug.Log(service1.GetHashCode() == service2.GetHashCode());
        }
    }
}