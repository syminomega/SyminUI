using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminData.NodeModel.Presets
{
    //数值类加法统一使用double
    public class NumberAddNode : INodeItem
    {
        public string Title => "数值相加";
        public List<INodeProperty> InputProperties { get; }
        public List<INodeProperty> OutputProperties { get; }

        #region Input
        public NodeProperty<double> InputNumberA { get; } = new("Num A", 0);
        public NodeProperty<double> InputNumberB { get; } = new("Num B", 0);
        #endregion

        #region Output
        public NodeProperty<double> OutputNumber { get; } = new("Result", 0);
        #endregion

        public NumberAddNode()
        {
            InputProperties = new List<INodeProperty>();
            OutputProperties = new List<INodeProperty>();
            InitProperties();
            InitFunctions();
        }
        private void InitProperties()
        {
            //添加数值类型转换
            InputNumberA.AddConverter<int>(input => input);
            InputNumberA.AddConverter<float>(input => input);
            //添加数值类型转换
            InputNumberB.AddConverter<int>(input => input);
            InputNumberB.AddConverter<float>(input => input);
            //添加到输入列表
            InputProperties.Add(InputNumberA);
            InputProperties.Add(InputNumberB);
            //添加到输出列表
            OutputProperties.Add(OutputNumber);
        }
        private void InitFunctions()
        {
            InputNumberA.PropertyChanged += InputNumberChanged;
            InputNumberB.PropertyChanged += InputNumberChanged;
        }

        private void InputNumberChanged(object obj)
        {
            var result = InputNumberA.Value + InputNumberB.Value;
            OutputNumber.Value = result;
        }
    }
}
