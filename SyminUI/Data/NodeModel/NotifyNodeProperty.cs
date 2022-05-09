using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyminData.NodeModel;
using System.ComponentModel;

namespace SyminUI.Data.NodeModel
{
    public class NotifyNodeProperty : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        INodeProperty _nodeProperty;
        public NotifyNodeProperty(INodeProperty nodeProperty)
        {
            _nodeProperty = nodeProperty;
            _propertyName = _nodeProperty.Name;
            _propertyValue = _nodeProperty.Value;
            //注册数值变化事件
            _nodeProperty.PropertyChanged += UpdateValue;
        }
        private void UpdateValue(object value)
        {
            PropertyValue = value;
        }

        private string _propertyName;
        public string PropertyName
        {
            get => _propertyName;
            set
            {
                _propertyName = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(PropertyName)));
            }
        }



        private object _propertyValue;
        public object PropertyValue
        {
            get => _propertyValue;
            set
            {
                _propertyValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PropertyValue)));
            }
        }


        public void Dispose()
        {
            //取消事件
            _nodeProperty.PropertyChanged -= UpdateValue;
        }
    }
}
