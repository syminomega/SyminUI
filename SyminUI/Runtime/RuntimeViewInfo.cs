using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Runtime
{
    internal class RuntimeViewInfo
    {
        public Type ViewType { get; set; }
        public IViewRenderer ViewRenderer { get; set; }
    }
}
