// ------------------------------
// Author:  Paul Anthony Buer
// ------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GithubSecurityLogPuller
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt")
                .CreateLogger();

            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<FormMain>();
                })
                .UseSerilog()
                .Build();

            RunApp(host);
        }


        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }


        static void RunApp(IHost host)
        {
            using (IServiceScope svcScope = host.Services.CreateScope())
            {
                IServiceProvider svc = svcScope.ServiceProvider;
                try
                {
                    FormMain formMain = svc.GetRequiredService<FormMain>();
                    Application.Run(formMain);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Github Security Log Puller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
