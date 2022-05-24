using System;

namespace AsFramework.Utils
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MonoSingletonPath : Attribute
    {
        public string PathInHierarchy => _pathInHierarchy;

        private readonly string _pathInHierarchy;
        
        public MonoSingletonPath(string pathInHierarchy)
        {
            _pathInHierarchy = pathInHierarchy;
        }

    
    }


}