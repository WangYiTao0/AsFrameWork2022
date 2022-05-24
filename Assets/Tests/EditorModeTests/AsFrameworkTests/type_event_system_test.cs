using System;
using AsFramework.Utils;
using NUnit.Framework;

namespace AsFramework.Tests
{
    public class type_event_system_test
    {
        [Test]
        public void TypeEventSystem_RegisterTest()
        {
            var receivedMsg = string.Empty;

            Action<string> onReceive = (msg) => { receivedMsg = msg; };
            
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Send("Hello");
            Assert.AreEqual(receivedMsg,"Hello");
            
            TypeEventSystem.UnRegister(onReceive);
        }

        [Test]
        public void TypeEventSystem_SendTest()
        {
            var receivecCount = 0;

            Action<string> onReceive = (msg) => { receivecCount++; };
            
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);

            TypeEventSystem.Send("Hello");
            
            Assert.AreEqual(receivecCount, 5);

            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
        }

        [Test]
        public void TypeEventSystem_UnRegisterTest()
        {
            var receivedCount = 0;
            Action<string> onReceive = (msg) => { receivedCount++; };
            
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);

            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);


            TypeEventSystem.Send("Hello");

            Assert.AreEqual(receivedCount, 2);

            // 为了避免影响其他的单元测试，所以要注销一下
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
        }
    }
}