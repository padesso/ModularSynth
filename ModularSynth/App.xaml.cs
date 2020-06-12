using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModularSynth.ViewModels;
using ModularSynth.ViewModels.Browser;
using ModularSynth.ViewModels.Rack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ModularSynth
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   ConfigureServices(context.Configuration, services);
               })
               .Build();

            ServiceProvider = host.Services;
        }

        private void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {
            //services.Configure<AppSettings>(configuration
            //    .GetSection(nameof(AppSettings)));

            //Register services here!
            //services.AddScoped<ICustomerService, CustomerService>();

            // Register all ViewModels.
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ModuleBrowserViewModel>();
            services.AddSingleton<ModuleRackViewModel>();

            services.AddTransient<SignalGeneratorViewModel>();
            services.AddTransient<PortViewModel>();  //Want this to create/die as control is added/removed

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            // Original code...
        }
    }
}
