using NUnit.Framework;
using UnityEngine;
using WFramework.Utiis;


namespace AsFramework.Tests
{
    public class resolution_check_tests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ResolutionCheck_LandScapeTests()
        {
            // 宽比高大，就是横屏
            
            Debug.Log(Screen.height);
            Debug.Log(Screen.width);
            Debug.LogFormat("是否是横屏:{0}", ResolutionCheck.IsLandscape);
            Assert.AreEqual(ResolutionCheck.IsLandscape, Screen.width > Screen.height);
            
        }
        
        [Test]
        public void ResolutionCheck_4_3_Tests()
        {
            Debug.Log(Screen.height);
            Debug.Log(Screen.width);
            Debug.LogFormat("是否是 4 : 3 分辨率? {0}", ResolutionCheck.IsPad);
        }
        
    }
}
