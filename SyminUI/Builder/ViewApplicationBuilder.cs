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
        /// Services for the application
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Generate the global used service provider
        /// 生成全局使用的 Service Provider
        /// </summary>
        /// <returns></returns>
        public IServiceProvider ApplyServices()
        {
            var provider = Services.BuildServiceProvider();
            //赋予当前进程全局
            ViewApplication.ServiceProvider = provider;
            return provider;
        }

    }
}
