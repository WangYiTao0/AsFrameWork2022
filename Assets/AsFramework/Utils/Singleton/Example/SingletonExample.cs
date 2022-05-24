using UnityEngine;

namespace AsFramework.Utils.Example
{
    public class SingletonExample : MonoBehaviour
    {
        void Start()
        {
            GameManager.Instance.PlayGame();

            var instance = GameManager.Instance;
            var instance1 = GameManager.Instance;

            Debug.Log(instance.GetHashCode() == instance1.GetHashCode());
        }
    }
    
    public class GameManager : Singleton<GameManager>
    {
        private GameManager(){}

        public void PlayGame()
        {
            Debug.Log("PlayGame");
        }
    }
}