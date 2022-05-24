using UnityEngine;

namespace AsFramework.Utils.Singleton.Example
{

    public class MonoSingletonExample : MonoBehaviour
    {

        public class GameManager : MonoSingleton<GameManager>
        {
            public override void OnSingletonInit()
            {
                Debug.Log("GameManager Init");
            }
        }
		
        void Start()
        {
            var instance1 = GameManager.Instance;
            var instance2 = GameManager.Instance;
			
            Debug.Log(instance1.GetHashCode() == instance2.GetHashCode());
        }
    }
}