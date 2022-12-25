using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;

namespace SyminUI
{

    public class State<T> : INotifyPropertyChanged, IState
    {
        private T? _value;
        public T? Value
        {
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <inheritdoc/>
        public Binding GetBinding()
        {
            Binding binding = new(nameof(Value))
            {
                Source = this,
                //TODO:绑定失败的时候高亮UI，或者重置数据
                NotifyOnValidationError= true,
            };
            return binding;
        }

        /// <summary>
        /// 允许隐式从泛型创建State对象
        /// </summary>
        /// <param name="valueIn"></param>
        public static implicit operator State<T>(T? valueIn)
        {
            State<T> state = new()
            {
                Value = valueIn
            };
            return state;
        }

        public static explicit operator Binding(State<T> stateIn)
        {
            Binding binding = new(nameof(Value))
            {
                Source = stateIn
            };
            return binding;
        }

    }
}
