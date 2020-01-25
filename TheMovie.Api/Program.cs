using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace TheMovie.Api
{
    public class Program
    {
        private const string AppSettings = "appsettings.json";
        private const string AppSettingsEnv = "appsettings.{0}.json";
        

        private static string _environmentName;

        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args);

            var configiration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettings)
                .AddJsonFile(string.Format(AppSettingsEnv, _environmentName), optional: true, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configiration)
                .CreateLogger();

            webHost.Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, config) =>
            {
                config.ClearProviders();
                _environmentName = hostingContext.HostingEnvironment.EnvironmentName;
            })
            .UseSerilog()
            .UseStartup<Startup>()
            .Build();
    }
}
