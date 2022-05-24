using System.Collections.Generic;
using UnityEngine;

namespace AsFramework.Utils.FSM
{
    public class FSM
    {
        // 定义函数指针类型
        public delegate void FSMTranslationCallfunc();

        /// <summary>
        /// 状态类
        /// </summary>
        public class FSMState
        {
            public string name;

            public FSMState(string name)
            {
                this.name = name;
            }

            /// <summary>
            /// 存储事件对应的条转
            /// </summary>
            public Dictionary<string, FSMTranslation> TranslationDict = new Dictionary<string, FSMTranslation>();
        }

        /// <summary>
        /// 跳转类
        /// </summary>
        public class FSMTranslation
        {
            public FSMState               fromState;
            public string                 name;
            public FSMState               toState;
            public FSMTranslationCallfunc callfunc; // 回调函数

            public FSMTranslation(FSMState fromState, string name, FSMState toState, FSMTranslationCallfunc callfunc)
            {
                this.fromState = fromState;
                this.toState = toState;
                this.name = name;
                this.callfunc = callfunc;
            }
        }

        // 当前状态
        private FSMState _curState;

        // 这部分是新增的,是原来的文章没有的
        public FSMState CurState
        {
            get { return _curState; }
        }

        Dictionary<string, FSMState> StateDict = new Dictionary<string, FSMState>();

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state">State.</param>
        public void AddState(FSMState state)
        {
            StateDict[state.name] = state;
        }

        /// <summary>
        /// 添加条转
        /// </summary>
        /// <param name="translation">Translation.</param>
        public void AddTranslation(FSMTranslation translation)
        {
            StateDict[translation.fromState.name].TranslationDict[translation.name] = translation;
        }

        /// <summary>
        /// 启动状态机
        /// </summary>
        /// <param name="state">State.</param>
        public void Start(FSMState state)
        {
            _curState = state;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="name">Name.</param>
        public void HandleEvent(string name)
        {
            if (_curState != null && _curState.TranslationDict.ContainsKey(name))
            {
                Debug.LogWarning("fromState:" + _curState.name);

                _curState.TranslationDict[name].callfunc();
                _curState = _curState.TranslationDict[name].toState;


                Debug.LogWarning("toState:" + _curState.name);
            }
        }
    }
}