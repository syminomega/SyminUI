using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SyminUI
{
    /// <summary>
    ///
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 获取数据绑定
        /// </summary>
        /// <returns></returns>
        public Binding GetBinding();
    }
}
