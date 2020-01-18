using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Infrastructure;
using TheMovie.Model.Settings;

namespace TheMovie.Api
{
    public class Startup
    {
        private const string MovieSettings = "MovieSettings";
        private const string HealthEndpoint = "/healthz";

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
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks(HealthEndpoint);

            // Configure swagger
            app.AddSwagger();
        }
    }
}
