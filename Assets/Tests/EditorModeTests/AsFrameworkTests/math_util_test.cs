using AsFramework.Utils;
using AsFramework.Utils.MathUtil;
using NUnit.Framework;
using UnityEngine;

namespace AsFramework.Tests
{
    public class math_util_test
    {
        [Test]
        public static void MathUtil_PercentTest()
        {
            var percent = 50;

            var trueCount = 0;
            
            // 随机 1000 次
            for (var i = 0; i < 1000; i++)
            {
                if (MathUtil.Percent(percent))
                {
                    trueCount++;
                }
            }

            Debug.Log(trueCount);

            Assert.IsTrue(trueCount < 600 && trueCount > 400);
        }
    }
}