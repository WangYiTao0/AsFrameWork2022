using AsFramework.Utils;
using NUnit.Framework;
using UnityEngine;

namespace AsFramework.Tests
{
    public class extensions_test
    {
        [Test]
        public static void Extension_PositionXTest()
        {
            var gameObject = new GameObject();

            gameObject.transform.PositionY(10);

            Assert.AreEqual(gameObject.transform.position.y, 10);

            gameObject.transform.PositionZ(20);

            Assert.AreEqual(gameObject.transform.position.z, 20);

            gameObject.transform.PositionXY(30,40);

            Assert.AreEqual(gameObject.transform.position.x, 30);
            Assert.AreEqual(gameObject.transform.position.y, 40);

            gameObject.transform.LocalPositionX(50);

            Assert.AreEqual(gameObject.transform.localPosition.x, 50);

            gameObject.transform.LocalPositionY(60);

            Assert.AreEqual(gameObject.transform.localPosition.y, 60);

            gameObject.transform.LocalPositionZ(70);

            Assert.AreEqual(gameObject.transform.localPosition.z, 70);

            gameObject.transform.LocalPositionXY(80,90);

            Assert.AreEqual(gameObject.transform.localPosition.x, 80);
            Assert.AreEqual(gameObject.transform.localPosition.y, 90);

            gameObject.transform.LocalIdentity();
            Assert.AreEqual(gameObject.transform.localPosition,Vector3.zero);
            Assert.AreEqual(gameObject.transform.localRotation,Quaternion.identity);
            Assert.AreEqual(gameObject.transform.localScale,Vector3.one);

            gameObject.transform.Identity();
            Assert.AreEqual(gameObject.transform.position,Vector3.zero);
            Assert.AreEqual(gameObject.transform.rotation,Quaternion.identity);
            Assert.AreEqual(gameObject.transform.lossyScale,Vector3.one);

        }
        
        [Test]
        public static void Extensions_ShowHideTest()
        {
            // GameObject 测试
            var gameObject = new GameObject();

            gameObject.Show();

            Assert.AreEqual(gameObject.activeSelf, true);

            gameObject.Hide();

            Assert.AreEqual(gameObject.activeSelf, false);

            // Transform 测试
            gameObject.transform.Show();

            Assert.AreEqual(gameObject.activeSelf, true);

            gameObject.transform.Hide();

            Assert.AreEqual(gameObject.activeSelf, false);

            // Component 测试
            var camera = gameObject.AddComponent<Camera>();

            camera.Show();

            Assert.AreEqual(gameObject.activeSelf, true);

            camera.Hide();

            Assert.AreEqual(gameObject.activeSelf, false);

        }

    }
}