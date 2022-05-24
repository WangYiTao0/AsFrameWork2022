using System;
using System.Collections.Generic;

namespace AsFramework.Utils
{
    public class TypeEventSystem
    {
        /// <summary>
        /// 接口 只负责存储在字典中
        /// </summary>
        interface IRegisterations
        {

        }

        class Registerations<T> : IRegisterations
        {
            /// <summary>
            /// 不需要 List<Action<T>> 了
            /// 因为委托本身就可以一对多注册
            /// </summary>
            public Action<T> OnReceives = obj => { };
        }

        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Type, IRegisterations> _typeEventDict = new Dictionary<Type, IRegisterations>();

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="onReceive"></param>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>(Action<T> onReceive)
        {
            var type = typeof(T);
            IRegisterations registerations = null;

            if (_typeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceives += onReceive;
            }
            else
            {
                //创建新的注册
                var reg = new Registerations<T>();
                reg.OnReceives += onReceive;
                //加入字典
                _typeEventDict.Add(type,reg);
            }
        }
        
        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="onReceive"></param>
        /// <typeparam name="T"></typeparam>
        public static void UnRegister<T>(Action<T> onReceive)
        {
            var type = typeof(T);
            IRegisterations registerations = null;
            if (_typeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceives -= onReceive;
            }
        }

        public static void Send<T>(T t)
        {
            var type = typeof(T);
            IRegisterations registerations = null;

            if (_typeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceives(t);
            }
        }
    }
}
                
