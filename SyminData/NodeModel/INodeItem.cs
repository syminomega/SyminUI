using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminData.NodeModel
{
    public interface INodeItem
    {
        /// <summary>
        /// 节点标题
        /// </summary>
        public string Title { get;}
        /// <summary>
        /// 输入节点列表
        /// </summary>
        public List<INodeProperty> InputProperties { get; }
        /// <summary>
        /// 输出节点列表
        /// </summary>
        public List<INodeProperty> OutputProperties { get; }
    }
}
