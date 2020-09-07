using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheMovie.Api.Configuration;
using TheMovie.Api.Infrastructure;
using TheMovie.Api.Middleware;
using TheMovie.Model.Common;
using TheMovie.Model.Settings;

namespace TheMovie.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceConfig = Configuration.GetSection(Constants.Service.ServiceSettings).Get<ServiceConfiguration>();

            services.AddControllers();

            // Registers health checks services
            services.AddHealthChecks();

            services.AddSingleton(new MovieSettings(serviceConfig.Movie.ApiKey, serviceConfig.Movie.BaseUrl));

            // Add own services
            services.AddMovieClientService();

            // Configure swagger
            services.AddSwaggerService();

            // Configure automapper
            services.AddAutomapperService();

            // Add http client service
            services.AddHttpClientService();

            // Add Open telemetry
            services.AddOpenTelemetryService(serviceConfig);
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

            app.UseHealthChecks(Constants.Service.HealthEndpoint);

            // Configure swagger
            app.AddSwagger();

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information(string.Format(Constants.Service.AppStartedLog, Constants.App.Name));
            });
        }
    }
}
