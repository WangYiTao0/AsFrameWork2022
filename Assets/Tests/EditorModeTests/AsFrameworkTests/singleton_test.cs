using AsFramework.Utils;
using NUnit.Framework;
using UnityEngine;

namespace AsFramework.Tests
{
    public class singleton_test
    {
        public class GameManager : Singleton<GameManager>
        {
            private GameManager(){}

            public void PlayGame()
            {
                Debug.Log("PlayGame");
            }
        }

        [Test]
        public static void Singleton_Test()
        {
            GameManager.Instance.PlayGame();

            var instanceA = GameManager.Instance;
            var instanceB = GameManager.Instance;

            Assert.AreSame(instanceA,instanceB);
        }
    }
}