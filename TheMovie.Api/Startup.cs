using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Infrastructure;
using TheMovie.Model.Infrastructure;

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

            services.Configure<MovieSettings>(options => Configuration.GetSection(MovieSettings).Bind(options));

            // Add own services
            services.AddMovieClientService();

            // Configure swagger
            services.AddSwaggerService();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseHealthChecks(HealthEndpoint);

            // Configure swagger
            app.AddSwagger();
        }
    }
}
