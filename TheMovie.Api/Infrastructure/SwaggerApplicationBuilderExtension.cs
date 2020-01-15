using Microsoft.AspNetCore.Builder;

namespace TheMovie.Api.Infrastructure
{
    public static class SwaggerApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Service API V1");
            });

            return app;
        }
    }
}
