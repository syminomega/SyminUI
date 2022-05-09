using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;

namespace SyminUI.Core
{
    public class State<T> : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public static implicit operator State<T>(T? valueIn)
        {
            State<T> state = new();
            state.Value = valueIn;
            return state;
        }

        public static explicit operator Binding(State<T> stateIn)
        {
            Binding textBinding = new(nameof(Value));
            textBinding.Source = stateIn;
            return textBinding;
        }

        //TODO:添加Binding的Convertor与运算
    }
}
