using System.Collections;
using AsFramework.Utils;
using UnityEngine;
using UnityEngine.TestTools;

namespace AsFramework.Tests.PlayModeTests
{
    public class mono_singleton_path_tests
    {
        [MonoSingletonPath("[Logic]/GameManager")]
        public class GameManager : MonoSingleton<GameManager> {}
        [MonoSingletonPath("[Framework]/ResManager")]
        public class ResManager : MonoSingleton<ResManager> {}
        [MonoSingletonPath("[Framework]/UIManager")]
        public class UIManager : MonoSingleton<UIManager> {}

        [MonoSingletonPath("[Framework]/SoundManager")]
        public class SoundManager : MonoSingleton<SoundManager> {}
        [MonoSingletonPath("[Logic]/ConfigManager")]
        public class ConfigManager : MonoSingleton<ConfigManager> {}
        [MonoSingletonPath("[Logic]/BattleManager")]

        public class BattleManager : MonoSingleton<BattleManager> {}
        [MonoSingletonPath("[Framework]/NetworkManager")]
        public class NetworkManager : MonoSingleton<NetworkManager> {}

        [UnityTest]

        public IEnumerator MonoSingletonPathTest()
        {
            var gameMgr = GameManager.Instance;
            var resMgr = ResManager.Instance;
            var uiMgr = UIManager.Instance;
            var soundMgr = SoundManager.Instance;
            var configMgr = ConfigManager.Instance;
            var battleMgr = BattleManager.Instance;
            var networkMgr = NetworkManager.Instance;
            yield return new WaitForSeconds(10f);
        }
    }
}