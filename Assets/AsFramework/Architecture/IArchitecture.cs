using System;

namespace AsFrameWork
{
    public interface IArchitecture
    {
        /// <summary>
        /// 注册系统
        /// </summary>
        void RegisterSystem<T>(T instance) where T : ISystem;

        /// <summary>
        /// 注册 Model
        /// </summary>
        void RegisterModel<T>(T instance) where T : IModel;


        /// <summary>
        /// 注册 Utility
        /// </summary>
        void RegisterUtility<T>(T instance) where T : IUtility;


        /// <summary>
        /// 获取 System
        /// </summary>
        T GetSystem<T>() where T : class, ISystem;
        
        /// <summary>
        /// 获取 Model
        /// </summary>
        T GetModel<T>() where T : class, IModel;

        /// <summary>
        /// 获取工具
        /// </summary>
        T GetUtility<T>() where T : class, IUtility;

        /// <summary>
        /// 发送命令
        /// </summary>
        void SendCommand<T>() where T : ICommand, new();

        /// <summary>
        /// 发送命令
        /// </summary>
        void SendCommand<T>(T command) where T : ICommand;

        
        /// <summary>
        /// 发送事件
        /// </summary>
        void SendEvent<T>() where T : new();

        /// <summary>
        /// 发送事件
        /// </summary>
        void SendEvent<T>(T e);

        /// <summary>
        /// 注册事件
        /// </summary>
        IUnRegister RegisterEvent<T>(Action<T> onEvent);

        /// <summary>
        /// 注销事件
        /// </summary>
        void UnRegisterEvent<T>(Action<T> onEvent);

    }
}