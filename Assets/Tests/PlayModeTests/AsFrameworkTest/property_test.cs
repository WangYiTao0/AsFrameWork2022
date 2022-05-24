using System.Collections;
using AsFramework.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AsFramework.Tests.PlayModeTests
{
    public class property_test 
    {
        public class BaseManager : MonoBehaviour
        {
            
        }

        public class GameManager : BaseManager, ISingleton
        {
            public static GameManager Instance
            {
                get
                {
                    return MonoSingletonProperty<GameManager>.Instance;
                }
            }
            
            public void OnSingletonInit()
            {
                Debug.Log("GameManager Init");
            }
        }

        public class BaseService
        {
            
        }

        public class BluetoothService : BaseManager, ISingleton
        {
            private BluetoothService(){}

            public static BluetoothService Instance
            {
                get
                {
                    return SingletonProperty<BluetoothService>.Instance;
                    
                }
            }
            
            public void OnSingletonInit()
            {
                Debug.Log("BluetoothService Init");
            }
        }

        [UnityTest]

        public IEnumerator SingletonPropertyTest()
        {
            var instance1 = GameManager.Instance;
            var instance2 = GameManager.Instance;

            Assert.AreSame(instance1,instance2);

            var service1 = BluetoothService.Instance;
            var service2 = BluetoothService.Instance;

            Assert.AreSame(service1,service2);

            yield return new WaitForSeconds(10f);
        }
        
    }
}
