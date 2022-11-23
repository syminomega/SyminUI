using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SyminUI;

namespace SyminViewTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = ViewApplication.CreateBuilder();
            var services = builder.Services;

            var serviceProvider = builder.ApplyServices();


        }
    }
}
