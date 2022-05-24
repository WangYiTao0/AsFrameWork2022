using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsFramework.Utils
{
    public class StateMachine
    {
        public IState CurrentState => _currentState;
        private IState _currentState;
        
        private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type,List<Transition>>();
        private List<Transition> _currentTransitions = new List<Transition>();
        private List<Transition> _anyTransitions = new List<Transition>();
        
        private static List<Transition> EmptyTransitions = new List<Transition>(0);
        public Action<IState> OnStateChanged;

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            _currentState.Tick();
        }
        
        public void SetState(IState state)
        {
            //防止重复进入相同的State
            if (_currentState == state)
                return;
            //改变状态前 调用前一个状态的OnExit
            _currentState?.OnExit();
            _currentState = state;
            
            //Debug.Log($"Changed to state {state}   {state.GetHashCode()}"); 
            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = EmptyTransitions;
            //改变状态后 调用像现在状态的OnExit
            _currentState.OnEnter();
            OnStateChanged?.Invoke(_currentState);
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }
      
            transitions.Add(new Transition(to, predicate));
        }
    
        public void AddAnyTransition(IState to, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(to, predicate));
        }
        
        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;
            return null;
        }
    }
}