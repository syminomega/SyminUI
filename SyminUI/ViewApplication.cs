using Microsoft.Extensions.DependencyInjection;
using SyminUI.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyminUI
{
    /// <summary>
    /// 程序构建工具
    /// </summary>
    public class ViewApplication
    {
        private static ViewApplication? _current;

        /// <summary>
        /// Get the <see cref="ViewApplication"/> instance of current application.
        /// 获取当前程序的 <see cref="ViewApplication"/> 实例。
        /// </summary>
        public static ViewApplication Current
        {
            get
            {
                if (_current == null)
                {
                    throw new NullReferenceException("ViewApplication has not been built. ");
                }

                return _current;
            }
            private set => _current = value;
        }

        internal ViewApplication(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Current = this;
        }

        /// <summary>
        /// The service provider of this view application.
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewApplicationBuilder"/> class.
        /// </summary>
        /// <returns>The <see cref="ViewApplicationBuilder"/>.</returns>
        public static ViewApplicationBuilder CreateBuilder()
        {
            var builder = new ViewApplicationBuilder();
            return builder;
        }
    }
}