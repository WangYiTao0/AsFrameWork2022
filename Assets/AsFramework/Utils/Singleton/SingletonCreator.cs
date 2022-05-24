using System;
using System.Reflection;

namespace AsFramework.Utils
{
    public static class SingletonCreator
    {
        public static T CreateSingleton<T>() where T : class, ISingleton
        {
            //通过反射去创建一个 ISingleton 的实例
            // 先获取所有非public的构造方法
            ConstructorInfo[] constructors = typeof(T).GetConstructors
                (BindingFlags.Instance | BindingFlags.NonPublic);
            // 从 constructor 中获取无参的构造方法
            ConstructorInfo constructor = Array.Find(constructors, c => c.GetParameters().Length == 0);
            
            if (constructor == null)
            {
                throw new Exception("Non-Public Constructor() not found! in " + typeof(T));
            }

            var retInstance = constructor.Invoke(null) as T;
            retInstance.OnSingletonInit();

            return retInstance;
        }
    }
}