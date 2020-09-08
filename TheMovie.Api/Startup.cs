using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheMovie.Api.Infrastructure;
using TheMovie.Api.Middleware;
using TheMovie.Model.Common;
using TheMovie.Model.Settings;

namespace TheMovie.Api
{
    public class Startup
    {
        private readonly static string MovieSettings = "MovieSettings";
        private readonly static string HealthEndpoint = "/healthz";
        private readonly static string AppStartedLog = "App {0} has been started";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Registers health checks services
            services.AddHealthChecks(); 

            services.AddSingleton(options => Configuration.GetSection(MovieSettings).Get<MovieSettings>());

            // Add own services
            services.AddMovieClientService();

            // Configure swagger
            services.AddSwaggerService();

            // Configure automapper
            services.AddAutomapperService();

            // Add http client service
            services.AddHttpClientService();

            // Add memory cache
            services.AddinMemoryStorage();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime applicationLifetime)
        {
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks(HealthEndpoint);

            // Configure swagger
            app.AddSwagger();

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information(string.Format(AppStartedLog, Constants.App.Name));
            });
        }
    }
}
