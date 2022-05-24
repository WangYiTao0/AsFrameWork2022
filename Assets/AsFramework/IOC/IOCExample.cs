using UnityEngine;

namespace AsFrameWork
{
    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            // 创建一个 IOC 容器
            var container = new IOCContainer();
            
            // 注册一个蓝牙管理器的实例
            container.Register(new BluetoothManager());
            
            // 根据类型获取蓝牙管理器的实例
            var bluetoothManager = container.Get<BluetoothManager>();
            
            //连接蓝牙
            bluetoothManager.Connect();
        }

        public class BluetoothManager
        {
            public void Connect()
            {
                Debug.Log("蓝牙连接成功");
            }
        }

    }
}