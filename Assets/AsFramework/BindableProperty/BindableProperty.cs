using System;

namespace AsFrameWork
{
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    _onValueChanged?.Invoke(value);
                }
            }
        }

        private Action<T> _onValueChanged = (v) => { }; // -+

        public IUnRegister RegisterOnValueChanged(Action<T> onValueChanged) // +
        {
            _onValueChanged += onValueChanged;
            return new BindablePropertyUnRegister<T>()
            {
                BindableProperty = this,
                OnValueChanged = onValueChanged
            };
        }

        public void UnRegisterOnValueChanged(Action<T> onValueChanged) // +
        {
            _onValueChanged -= onValueChanged;
        }
    }

    public class BindablePropertyUnRegister<T> : IUnRegister where T : IEquatable<T> // +
    {
        public BindableProperty<T> BindableProperty { get; set; }
        
        public Action<T> OnValueChanged { get; set; }
        
        public void UnRegister()
        {
            BindableProperty.UnRegisterOnValueChanged(OnValueChanged);
        }
    }

}
