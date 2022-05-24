using UnityEngine;

namespace AsFramework.Utils.MathUtil
{
    public static class MathUtil 
    {
        /// <summary>
        /// 输入百分比返回是否命中概率
        /// </summary>
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
    }
}