using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminData.NodeModel
{
    public class NodeProperty<T> : INodeProperty<T> where T : notnull
    {
        public string Name { get; private set; }
        public event Action<object>? PropertyChanged;
        //断开节点的时候使用的默认值
        private readonly T _defaultValue;

        public Type PropertyType => typeof(T);

        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(_value);
            }
        }

        public Dictionary<Type, Func<object, T>> InputConverters => new();

        object INodeProperty.Value => this.Value;


        private INodeProperty? _inputNode;
        public INodeProperty? InputNode
        {
            get => _inputNode;
            set
            {
                //解除之前节点的事件监听
                if (_inputNode != null)
                {
                    _inputNode.PropertyChanged -= this.UpdateProperty;
                }
                //输入节点赋值为空的时候，重置为默认值
                if (value == null)
                {
                    //设置为空
                    _inputNode = null;
                    this.Reset();
                }
                //替换为新的节点，绑定数据更新响应，更新节点数据
                else
                {
                    _inputNode = value;
                    this.UpdateProperty(_inputNode.Value);
                    //监听输入节点数据变化事件
                    _inputNode.PropertyChanged += this.UpdateProperty;
                }
            }
        }


        /// <summary>
        /// 初始化变量属性，需要提供默认值
        /// </summary>
        /// <param name="defaultValue"></param>
        public NodeProperty(string name, T defaultValue)
        {
            Name = name;
            _defaultValue = defaultValue;
            _value = defaultValue;
            //添加默认值转换器
            this.AddConverter<T>(input => input);
        }


        public void AddConverter<In>(Func<In, T> converter) where In : notnull
        {
            if (InputConverters.ContainsKey(typeof(In)))
            {
                throw new InvalidOperationException("该类型转换器已经存在，不可重复添加");
            }
            var commonConverter = new Func<object, T>(o => converter.Invoke((In)o));
            InputConverters.Add(typeof(In), commonConverter);
        }

        public void UpdateProperty<In>(In input) where In : notnull
        {
            var inputType = input.GetType();
            //获取输入数值的类型
            if (InputConverters.TryGetValue(inputType, out var converter))
            {
                //更新数值
                Value = converter.Invoke(input);
                return;
            }
            else
            {
                throw new ArgumentException($"没有找到符合{inputType.Name}的数值转换器");
            }
        }
        //恢复默认值
        public void Reset()
        {
            //重设为默认值，触发属性变化事件
            Value = _defaultValue;
        }

    }
}
