using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminData.NodeModel
{
    /// <summary>
    /// NodeItem Property
    /// </summary>
    public interface INodeProperty
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 属性变量类型
        /// </summary>
        public Type PropertyType { get; }
        /// <summary>
        /// 更新属性
        /// </summary>
        /// <typeparam name="In"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public void UpdateProperty<In>(In input) where In : notnull;
        /// <summary>
        /// 属性值（只读）
        /// </summary>
        public object Value { get; }
        /// <summary>
        /// 输入的节点
        /// </summary>
        public INodeProperty? InputNode { get; set; }
        /// <summary>
        /// 属性发生变化时触发
        /// </summary>
        public event Action<object>? PropertyChanged;
        /// <summary>
        /// 重置为默认值
        /// </summary>
        public void Reset();
    }
    public interface INodeProperty<T> : INodeProperty where T : notnull
    {
        /// <summary>
        /// 属性变量值
        /// </summary>
        public new T Value { get; set; }
        /// <summary>
        /// 转换模块列表
        /// </summary>
        public Dictionary<Type, Func<object, T>> InputConverters { get; }
        /// <summary>
        /// 添加数值类型转换模块
        /// </summary>
        /// <typeparam name="In"></typeparam>
        /// <param name="converter"></param>
        public void AddConverter<In>(Func<In, T> converter) where In : notnull;
    }
}
