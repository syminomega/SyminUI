using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Builder
{
    /// <summary>
    /// 应用程序构建
    /// </summary>
    public class ViewApplicationBuilder
    {
        /// <summary>
        /// 初始化 Builder
        /// </summary>
        public ViewApplicationBuilder()
        {
            Services = new ServiceCollection();
        }

        /// <summary>
        /// A collection of services for the application to compose.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Build the <see cref="ViewApplication"/>.
        /// 创建 <see cref="ViewApplication"/> 实例
        /// </summary>
        public ViewApplication Build()
        {
            var app = new ViewApplication(Services.BuildServiceProvider());
            //TODO:添加config
            return app;
        }
    }
}
