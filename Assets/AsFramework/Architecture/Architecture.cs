using System;
using System.Collections.Generic;

namespace AsFrameWork
{
    /// <summary>
    /// Architecture
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否已经初始化完成
        /// </summary>
        private bool _initialized = false;

        /// <summary>
        /// 用于初始化的 Systems 的缓存1
        /// </summary>
        private readonly List<ISystem> _systems = new List<ISystem>();
        /// <summary>
        /// 用于初始化的 Models 的缓存
        /// </summary>
        private readonly List<IModel> _models = new List<IModel>();
        
        // 提供一个注册 Model 的 API
        public void RegisterSystem<TSystem>(TSystem instance) where TSystem : ISystem
        {
            // 需要给 Model 赋值一下
            instance.SetArchitecture(this);

            _container.Register<TSystem>(instance);

            // 如果初始化过了
            if (_initialized)
            {
                instance.Init();
            }
            else
            {
                // 添加到 Model 缓存中，用于初始化
                _systems.Add(instance);
            }
        }

        
        public void RegisterModel<TModel>(TModel instance) where TModel : IModel
        {
            // 需要给 Model 赋值一下
            instance.SetArchitecture(this);
            _container.Register<TModel>(instance);

            // 如果初始化过了
            if (_initialized)
            {
                instance.Init();
            }
            else
            {
                // 添加到 Model 缓存中，用于初始化
                _models.Add(instance);
            }
        }

        #region 类似单例模式 但是仅在内部课访问

        /// <summary>
        /// 注册补丁
        /// </summary>
        public static Action<T> OnRegisterPatch = architecture => { };

        private static T _architecture = null;

        /// <summary>
        /// 接口
        /// </summary>
        public static IArchitecture Interface
        {
            get
            {
                if (_architecture == null)
                {
                    MakeSureArchitecture();
                }

                return _architecture;
            }
        }

        // 确保 Container 是有实例的
        /// <summary>
        /// 实例化Container
        /// </summary>
        static void MakeSureArchitecture()
        {
            if (_architecture == null)
            {
                _architecture = new T();
                _architecture.Init();

                // 调用
                OnRegisterPatch?.Invoke(_architecture);

                // 初始化 Model
                foreach (var architectureModel in _architecture._models)
                {
                    architectureModel.Init();
                }

                // 清空 Model
                _architecture._models.Clear();

                // 初始化 System

                foreach (var architectureSystem in _architecture._systems)
                {
                    architectureSystem.Init();
                }

                // 清空 System
                _architecture._systems.Clear();

                _architecture._initialized = true;
            }
        }

        #endregion

        private readonly IOCContainer _container = new IOCContainer();

        // 留给子类注册模块
        protected abstract void Init();

        // 提供一个注册模块的 API
        public static void Register<TT>(TT instance)
        {
            MakeSureArchitecture();
            _architecture._container.Register<TT>(instance);
        }

        public void RegisterUtility<TUtility>(TUtility instance) where TUtility : IUtility
        {
            _container.Register<TUtility>(instance);
        }

        public TSystem GetSystem<TSystem>() where TSystem : class, ISystem
        {
            return _container.Get<TSystem>();
        }
        
        public TModel GetModel<TModel>() where TModel : class, IModel
        {
            return _container.Get<TModel>();
        }

        public TUtility GetUtility<TUtility>() where TUtility : class, IUtility
        {
            return _container.Get<TUtility>();
        }

        public void SendCommand<TCommand>() where TCommand : ICommand, new()
        {
            var command = new TCommand();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        private readonly ITypeEventSystem _typeEventSystem = new TypeEventSystem();

        public void SendEvent<TEvent>() where TEvent : new()
        {
            _typeEventSystem.Send<TEvent>();
        }

        public void SendEvent<TEvent>(TEvent e)
        {
            _typeEventSystem.Send<TEvent>(e);
        }

        public IUnRegister RegisterEvent<TEvent>(Action<TEvent> onEvent)
        {
            return _typeEventSystem.Register<TEvent>(onEvent);
        }

        public void UnRegisterEvent<TEvent>(Action<TEvent> onEvent)
        {
            _typeEventSystem.UnRegister<TEvent>(onEvent);
        }
    }
}