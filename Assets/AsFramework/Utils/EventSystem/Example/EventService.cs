using System;
using System.Collections.Generic;

namespace AsFramework.Utils.Example 
{
    public class EventService  
    {
        private List<Action> mUnRegisterEventActions = new List<Action>();

        public void Register<T> (Action<T> onReceive)
        {
            TypeEventSystem.Register<T>(onReceive);

            mUnRegisterEventActions.Add(()=>{
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
            mUnRegisterEventActions.ForEach(action=>action());
            mUnRegisterEventActions.Clear();
        }
    }
}