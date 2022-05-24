using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsFramework.Utils
{
    public class AsBehaviour : MonoBehaviour
    {
        private readonly List<Action> _unRegisterEventActions = new List<Action>();
    
        public void Register<T> (Action<T> onReceive)
        {
            TypeEventSystem.Register<T>(onReceive);

            _unRegisterEventActions.Add(()=>{
                TypeEventSystem.UnRegister<T>(onReceive);
            });
        }

        public void Send<T>(T eventKey)
        {
            TypeEventSystem.Send<T>(eventKey);
        }

        public void UnRegister<T>(Action<T> onReceive)
        {
            TypeEventSystem.UnRegister<T>(onReceive);
        }

        public void UnRegisterAll()
        {
            _unRegisterEventActions.ForEach(action=>action());
            _unRegisterEventActions.Clear();
        }
    }
}