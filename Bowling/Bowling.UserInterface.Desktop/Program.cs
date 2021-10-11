using System;
using System.Windows.Forms;
using Bowling.Application.Repositories;
using Bowling.Persistence.Singleton.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bowling.UserInterface.Desktop
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);


            using var serviceProvider = services.BuildServiceProvider();
            var form1 = serviceProvider.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(form1);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBowlingCommandsRepository, BowlingCommandsRepository>();
            services.AddScoped<IBowlingQueriesRepository, BowlingQueriesRepository>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<Form1>();
        }
    }
}
