using System.Collections;
using AsFramework.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AsFramework.Tests.PlayModeTests
{
    public class mono_singleton_test
    {

        public class MonoClassA : MonoSingleton<MonoClassA>
        {
            public override void OnSingletonInit()
            {
                Debug.Log("MonoClassA Init");
            }
        }

        [UnityTest]
        public IEnumerator Singleton_MonoSingletonTest()
        {
            var objA = MonoClassA.Instance;
            var objB = MonoClassA.Instance;

            Assert.AreSame(objA, objB);

            // 测试可以找到 MonoClassA
            var monoClass = GameObject.Find("MonoClassA");

            Assert.IsNotNull(monoClass);
            
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1.0f);
        }
    }
}
