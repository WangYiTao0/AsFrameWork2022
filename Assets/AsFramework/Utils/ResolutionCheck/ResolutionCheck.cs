using UnityEngine;

namespace WFramework.Utiis
{
    public class ResolutionCheck : MonoBehaviour
    {
        public static bool IsLandscape
        {
            get { return Screen.width > Screen.height; }
        }

        public static bool IsPad
        {
            get
            {
                return IsRatio(4, 3);
            }
        }

        public static bool IsPhone16_9
        {
            get
            {
                return IsRatio(16, 9);
            }
        }

        public static bool IsRatio(float width, float height)
        {
            var aspectRatio = IsLandscape
                ? (float) Screen.width / Screen.height
                : (float) Screen.height / Screen.width;

            var destinationRatio = width / height;
            
            return aspectRatio > destinationRatio - 0.05f && aspectRatio < destinationRatio + 0.05f;
        }
    }
}