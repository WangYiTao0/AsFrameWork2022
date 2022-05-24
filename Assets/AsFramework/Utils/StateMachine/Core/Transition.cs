using System;

namespace AsFramework.Utils
{
    public class Transition
    {
        public readonly IState To;
        public readonly Func<bool> Condition;

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }
}