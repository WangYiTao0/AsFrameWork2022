using System;
using System.Collections.Generic;

namespace AsFrameWork
{
    public class IOCContainer
    {
        /// <summary>
        /// 实例
        /// </summary>
        public Dictionary<Type, object> mInstances = new Dictionary<Type, object>();

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        public void Register<T>(T instance)
        {
            var key = typeof(T);

            if (mInstances.ContainsKey(key))
            {
                mInstances[key] = instance;
            }
            else
            {
                mInstances.Add(key,instance);
            }
        }

        /// <summary>
        /// 获取
        /// <summary>
        public T  Get<T>() where T : class
        {
            var key = typeof(T);
            
            object retObj;
            
            if(mInstances.TryGetValue(key,out retObj))
            {
                return retObj as T;
            }

            return null;
        }

    }
}